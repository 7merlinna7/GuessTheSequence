using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Develop.Runtime.Utilities.Timer;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.AI.States;
using Assets._Project.Ecs.Gameplay.Features.Attack;
using Assets._Project.Ecs.Gameplay.Features.InputFeature;
using Assets._Project.Ecs.Utilities.Conditions;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.AI
{
    public class BrainsFactory 
    {
        private readonly DIContainer _container;
        private readonly TimerServiceFactory _timerServiceFactory;
        private readonly AIBrainsContext _brainsContext;
        private readonly IInputService _inputInputService;
        private readonly MouseInputForHorizontalRotation _mouseInput;
        private readonly EntitiesLifeContext _entitiesLifeContext;

        public BrainsFactory(DIContainer container)
        {
            _container = container;
            _timerServiceFactory = _container.Resolve<TimerServiceFactory>();
            _brainsContext = _container.Resolve<AIBrainsContext>();
            _inputInputService = _container.Resolve<IInputService>();
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
            _mouseInput = _container.Resolve<MouseInputForHorizontalRotation>();
        }

        public StateMachineBrain CreateMainHeroBrain(Entity entity)
        {
            AIStateMachine combatState = CreatePlayerInputAttackStateMachine(entity,_mouseInput);
            PlayerInputMovementState movementState = new PlayerInputMovementState(entity,_inputInputService);

            ICompositeCondition fromMovementToCombatStateContition = new CompositeCondition()
                .Add(new FuncCondition(() => _inputInputService.Direction == Vector3.zero));

            ICompositeCondition fromCombatToMovementStateCondition = new CompositeCondition()
                .Add(new FuncCondition(() => _inputInputService.Direction != Vector3.zero));

            AIStateMachine stateMachine = new AIStateMachine();

            stateMachine.AddState(movementState);
            stateMachine.AddState(combatState);

            stateMachine.AddTransition(movementState,combatState,fromMovementToCombatStateContition);
            stateMachine.AddTransition(combatState,movementState,fromCombatToMovementStateCondition);

            StateMachineBrain brain = new StateMachineBrain(stateMachine);
            _brainsContext.SetFor(entity,brain);

            return brain;
        }

        public StateMachineBrain CreateSmartTeleportingGhostBrain(Entity entity, ITargetSelector targetSelector)
        {
            ReactiveVariable<Entity> currentTarget = entity.CurrentTarget;

            AIStateMachine combatState = CreateSmartTeleportingGhost(entity);
            EmptyState idleState = new EmptyState();

            AIStateMachine behaviour = new AIStateMachine();

            float minEnergyToRecharge = entity.MaxTeleportEnergy.Value * 0.4f;

            ICompositeCondition fromCombatToIdleCondition = new CompositeCondition(LogicOperations.Or)
                .Add(new FuncCondition(() => entity.CurrentTeleportEnergy.Value < minEnergyToRecharge));

            ICompositeCondition fromIdleToCombatCondition = new CompositeCondition()
                .Add(new FuncCondition(() => entity.CurrentTeleportEnergy.Value > minEnergyToRecharge));

            behaviour.AddState(combatState);
            behaviour.AddState(idleState);

            behaviour.AddTransition(combatState,idleState,fromCombatToIdleCondition);
            behaviour.AddTransition(idleState,combatState,fromIdleToCombatCondition);

            FindTargetState findTargetState = new FindTargetState(targetSelector, _entitiesLifeContext, entity);
            AIParallelState parallelState = new AIParallelState(findTargetState, behaviour);

            AIStateMachine rootStateMachine = new AIStateMachine();
            rootStateMachine.AddState(parallelState);

            StateMachineBrain brain = new StateMachineBrain(rootStateMachine);
            _brainsContext.SetFor(entity, brain);

            return brain;
        }

        public StateMachineBrain CreateCommonTeleportingGhostBrain(Entity entity)
        {
            AIStateMachine teleportState = CreateCommonTeleportingGhost(entity);
            StateMachineBrain brain = new StateMachineBrain(teleportState);

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
            List<IDisposable> disposables = new List<IDisposable>();

            Transform transform = entity.Transform;
            ReactiveVariable<Entity> currentTarget = entity.CurrentTarget;

            TeleportationState teleportationState = new TeleportationState(entity);
            RotateToTargetState rotateRandomState = new RotateToTargetState(entity);

            ICondition canTeleportToTarget = entity.CanTeleportToTarget;

            TimerService idleTimer = _timerServiceFactory.Create(2f);
            disposables.Add(idleTimer);
            disposables.Add(rotateRandomState.Entered.Subscribe(idleTimer.Restart));

            ICompositeCondition fromTeleportToRotateCondition = new CompositeCondition()
                .Add(canTeleportToTarget);

            ICompositeCondition fromRotateToTeleportCondition = new CompositeCondition()
                .Add(new FuncCondition(() => idleTimer.IsOver))
                .Add(new FuncCondition(() => currentTarget!= null));

            AIStateMachine stateMachine = new AIStateMachine();
            stateMachine.AddState(rotateRandomState);
            stateMachine.AddState(teleportationState);

            stateMachine.AddTransition(rotateRandomState, teleportationState, fromRotateToTeleportCondition);
            stateMachine.AddTransition(teleportationState, rotateRandomState, fromTeleportToRotateCondition);

            return stateMachine;
        }

        private AIStateMachine CreateCommonTeleportingGhost(Entity entity)
        {
            List<IDisposable> disposables = new List<IDisposable>();

            TeleportationState teleportationState = new TeleportationState(entity);
            RotateRandomState rotateRandomState = new RotateRandomState(entity);

            ICondition canTeleport = entity.CanTeleport;

            TimerService idleTimer = _timerServiceFactory.Create(2f);
            disposables.Add(idleTimer);
            disposables.Add(rotateRandomState.Entered.Subscribe(idleTimer.Restart));

            ICompositeCondition fromTeleportToRotateCondition = new CompositeCondition()
                .Add(canTeleport);

            FuncCondition fromRotateToTeleportCondition = new FuncCondition(() => idleTimer.IsOver);

            AIStateMachine stateMachine = new AIStateMachine();
            stateMachine.AddState(rotateRandomState);
            stateMachine.AddState(teleportationState);

            stateMachine.AddTransition(rotateRandomState,teleportationState,fromRotateToTeleportCondition);
            stateMachine.AddTransition(teleportationState,rotateRandomState,fromTeleportToRotateCondition);


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

        private AIStateMachine CreatePlayerInputAttackStateMachine(Entity entity, IInputService inputService)
        {
            PlayerInputRotationState rotationState = new PlayerInputRotationState(entity,inputService);
            AttackTriggerState attackTriggerState = new AttackTriggerState(entity);

            ICondition canAttack = entity.CanStartAttack;
            ReactiveVariable<bool> inAttackProcess = entity.InAttackProcess;

            ICompositeCondition anyMouseButtonclicked = new CompositeCondition(LogicOperations.Or)
                .Add(new FuncCondition(() =>Input.GetKeyDown(KeyCode.Mouse0)))
                .Add(new FuncCondition(() => Input.GetKeyDown(KeyCode.Mouse1)));

            ICompositeCondition fromRotateToAttackCondition = new CompositeCondition()
                .Add(anyMouseButtonclicked)
                .Add(canAttack);

            ICondition fromAttackToRotateStateCondition = new FuncCondition(() => inAttackProcess.Value == false);

            AIStateMachine stateMachine = new AIStateMachine();
            stateMachine.AddState(rotationState);
            stateMachine.AddState(attackTriggerState);

            stateMachine.AddTransition(rotationState,attackTriggerState,fromRotateToAttackCondition);
            stateMachine.AddTransition(attackTriggerState,rotationState,fromAttackToRotateStateCondition);

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