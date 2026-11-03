using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Develop.Runtime.Utilities.Timer;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.AI.States;
using Assets._Project.Ecs.Gameplay.Features.InputFeature;
using Assets._Project.Ecs.Utilities.Conditions;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets._Project.Ecs.Gameplay.Features.AI
{
    public class BrainsFactory 
    {
        private readonly DIContainer _container;
        private readonly TimerServiceFactory _timerServiceFactory;
        private readonly AIBrainsContext _brainsContext;
        private readonly IInputService _inputInputService;
        private readonly EntitiesLifeContext _entitiesLifeContext;

        public BrainsFactory(DIContainer container)
        {
            _container = container;
            _timerServiceFactory = _container.Resolve<TimerServiceFactory>();
            _brainsContext = _container.Resolve<AIBrainsContext>();
            _inputInputService = _container.Resolve<IInputService>();
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
        }

        public StateMachineBrain CreateMainHeroBrain(Entity entity, ITargetSelector targetSelector)
        {
            AIStateMachine combatState = CreateAutoAttackStateMachine(entity);

            PlayerInputMovementState movementState = new PlayerInputMovementState(entity,_inputInputService);

            ReactiveVariable<Entity> currentTarget = entity.CurrentTarget;

            ICompositeCondition fromMovementToCombatStateContition = new CompositeCondition()
                .Add(new FuncCondition(() => currentTarget.Value != null))
                .Add(new FuncCondition(() => _inputInputService.Direction == Vector3.zero));

            ICompositeCondition fromCombatToMovementStateCondition = new CompositeCondition(LogicOperations.Or)
                .Add(new FuncCondition(() => currentTarget.Value == null))
                .Add(new FuncCondition(() => _inputInputService.Direction != Vector3.zero));

            AIStateMachine behaviour = new AIStateMachine();

            behaviour.AddState(movementState);
            behaviour.AddState(combatState);

            behaviour.AddTransition(movementState,combatState,fromMovementToCombatStateContition);
            behaviour.AddTransition(combatState,movementState,fromCombatToMovementStateCondition);

            //parallel StateMachine
            FindTargetState findTargetState = new FindTargetState(targetSelector,_entitiesLifeContext,entity);
            AIParallelState parallelState = new AIParallelState(findTargetState,behaviour);

            AIStateMachine rootStateMachine = new AIStateMachine();
            rootStateMachine.AddState(parallelState);

            StateMachineBrain brain = new StateMachineBrain(rootStateMachine);
            _brainsContext.SetFor(entity,brain);

            return brain;
        }

        public StateMachineBrain CreateSmartTeleportingGhostBrain(Entity entity, ITargetSelector targetSelector)
        {
            AIStateMachine combatState = CreateSmartTeleportingGhost(entity);

            FindTargetState findTargetState = new FindTargetState(targetSelector, _entitiesLifeContext, entity);
            AIParallelState parallelState = new AIParallelState(findTargetState, combatState);

            AIStateMachine rootStateMachine = new AIStateMachine();
            rootStateMachine.AddState(parallelState);

            StateMachineBrain brain = new StateMachineBrain(rootStateMachine);
            _brainsContext.SetFor(entity, brain);

            return brain;
        }

        public StateMachineBrain CreateCommonTeleportingGhostBrain(Entity entity)
        {
            List<IDisposable> disposables = new List<IDisposable>();

            AIStateMachine teleportState = CreateCommonTeleportingGhost(entity);
            EmptyState idleState = new EmptyState();

            TimerService idleTimer = _timerServiceFactory.Create(2f);
            disposables.Add(idleTimer);
            disposables.Add(idleState.Entered.Subscribe(idleTimer.Restart));

            ReactiveVariable<bool> inTeleportProcess = entity.InTeleportProcess;

            FuncCondition teleportToIdleCondition = new FuncCondition(() =>
            {
                Debug.Log(inTeleportProcess.Value == false);
                return inTeleportProcess.Value == false;
            });
            FuncCondition idleToTeleportCondition = new FuncCondition(() => idleTimer.IsOver);

            AIStateMachine stateMachine = new AIStateMachine(disposables);
            stateMachine.AddState(idleState);
            stateMachine.AddState(teleportState);

            stateMachine.AddTransition(idleState, teleportState, idleToTeleportCondition);
            stateMachine.AddTransition(teleportState, idleState, teleportToIdleCondition);

            StateMachineBrain brain = new StateMachineBrain(stateMachine);

            _brainsContext.SetFor(entity,brain);

            return brain;
        }

        public StateMachineBrain CreateWalkingGhostBrain(Entity entity)
        {
            AIStateMachine stateMachine = CreateRandomMovementStateMashine(entity);
            StateMachineBrain brain = new StateMachineBrain(stateMachine);

            _brainsContext.SetFor(entity, brain);

            return brain;
        }

        ////////////////////////////////////////////////
        
        private AIStateMachine CreateSmartTeleportingGhost(Entity entity)
        {
            TeleportationState smartTeleportationState = new TeleportationState(entity);
            EmptyState idleState = new EmptyState();

            FuncCondition teleportToIdleCondition = new FuncCondition(() => entity.CurrentTeleportEnergy.Value < entity.MaxTeleportEnergy.Value * 0.4f);
            FuncCondition idleToTeleportCondition = new FuncCondition(() => entity.CurrentTeleportEnergy.Value >= entity.MaxTeleportEnergy.Value * 0.4f);

            AIStateMachine stateMachine = new AIStateMachine();
            stateMachine.AddState(smartTeleportationState);
            stateMachine.AddState(idleState);

            stateMachine.AddTransition(smartTeleportationState, idleState, teleportToIdleCondition);
            stateMachine.AddTransition(idleState, smartTeleportationState, idleToTeleportCondition);

            return stateMachine;
        }

        private AIStateMachine CreateCommonTeleportingGhost(Entity entity)
        {
            TeleportationState teleportationState = new TeleportationState(entity);
            RotateRandomState rotateRandomState = new RotateRandomState(entity);

            //FuncCondition fromTeleportToRotateCondition = new FuncCondition(() => entity.InTeleportProcess.Value == false);

            FuncCondition fromRotateToTeleportCondition = new FuncCondition(() => rotateRandomState.InRotateProcess == false);

            AIStateMachine stateMachine = new AIStateMachine();
            stateMachine.AddState(rotateRandomState);
            stateMachine.AddState(teleportationState);

            stateMachine.AddTransition(rotateRandomState,teleportationState,fromRotateToTeleportCondition);
            //stateMachine.AddTransition(teleportationState,rotateRandomState,fromTeleportToRotateCondition);


            return stateMachine;
        }

        private AIStateMachine CreateRandomMovementStateMashine(Entity entity)
        {
            List<IDisposable> disposables = new List<IDisposable>();

            RandomMovementState randomMovementState = new RandomMovementState(entity,0.5f);
            EmptyState emptyState = new EmptyState();

            TimerService movementTimer = _timerServiceFactory.Create(2f);
            disposables.Add(movementTimer);
            disposables.Add(randomMovementState.Entered.Subscribe(movementTimer.Restart));

            TimerService idleTimer = _timerServiceFactory.Create(3f);
            disposables.Add(idleTimer);
            disposables.Add(emptyState.Entered.Subscribe(idleTimer.Restart));

            FuncCondition movementTimerEndedCondition = new FuncCondition(() => movementTimer.IsOver);
            FuncCondition idleTimerEndedCondition = new FuncCondition(() => idleTimer.IsOver);

            AIStateMachine stateMachine = new AIStateMachine(disposables);
            stateMachine.AddState(randomMovementState);
            stateMachine.AddState(emptyState);

            stateMachine.AddTransition(randomMovementState,emptyState,movementTimerEndedCondition);
            stateMachine.AddTransition(emptyState,randomMovementState,idleTimerEndedCondition);

            return stateMachine;
        }

        private AIStateMachine CreateAutoAttackStateMachine(Entity entity)
        {
            RotateToTargetState rotateToTargetState = new RotateToTargetState(entity);

            AttackTriggerState attackTriggerState = new AttackTriggerState(entity);

            ICondition canAttack = entity.CanStartAttack;
            Transform transform = entity.Transform;
            ReactiveVariable<Entity> currentTarget = entity.CurrentTarget;

            ICompositeCondition fromRotateToAttackCondition = new CompositeCondition()
                .Add(canAttack)
                .Add(new FuncCondition(() =>
                {
                    Entity target = currentTarget.Value;

                    if (target == null)
                        return false;

                    float angleToTarget = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(target.Transform.position - transform.position));
                    return angleToTarget < 1f;
                }));

            ReactiveVariable<bool> inAttackProcess = entity.InAttackProcess;

            ICondition fromAttackToRotateStateCondition = new FuncCondition(()=> inAttackProcess.Value == false);

            AIStateMachine stateMachine = new AIStateMachine();
            stateMachine.AddState(rotateToTargetState);
            stateMachine.AddState(attackTriggerState);

            stateMachine.AddTransition(rotateToTargetState,attackTriggerState,fromRotateToAttackCondition);
            stateMachine.AddTransition(attackTriggerState,rotateToTargetState,fromAttackToRotateStateCondition);

            return stateMachine;
        }
    }
}