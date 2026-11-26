using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.AI.States;
using Assets._Project.Ecs.Gameplay.Features.AI.States.TargetSelectors;
using Assets._Project.Ecs.Gameplay.Features.TowerFeature;
using Assets._Project.Ecs.Utilities.Conditions;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.AI
{
    public class BrainsFactory 
    {
        private readonly DIContainer _container;
        private readonly AIBrainsContext _brainsContext;

        public BrainsFactory(DIContainer container)
        {
            _container = container;
            _brainsContext = _container.Resolve<AIBrainsContext>();
        }

        public StateMachineBrain CreateStayingRangeEntityBrain(Entity entity)
        {
            FindTargetState findTargetState = new FindTargetState(entity,new NearestDamagebleTargetSelector(entity),_container.Resolve<EntitiesLifeContext>());
            AIStateMachine behaviour = CreateFollowTargetStateMachine(entity);

            AIParallelState parallelState = new AIParallelState(findTargetState, behaviour);

            AIStateMachine rootStateMachine = new AIStateMachine();
            rootStateMachine.AddState(parallelState);

            StateMachineBrain brain = new StateMachineBrain(rootStateMachine);

            _brainsContext.SetFor(entity, brain);

            return brain;
        }

        private AIStateMachine CreateFollowTargetStateMachine(Entity entity)
        {
            RotateToTargetState rotateToTargetState = new RotateToTargetState(entity);
            AttackRepeatState attackRepeatState = new AttackRepeatState(entity);

            ReactiveVariable<Vector3> rotatioinDirection = entity.RotationDirection;

            ICondition canAttack = entity.CanStartAttack;
            Transform transform = entity.Transform;
            ReactiveVariable<Entity> currentTarget = entity.CurrentTarget;

            ICompositeCondition rotateToAttackStateCondition = new CompositeCondition()
                .Add(canAttack)
                .Add(new FuncCondition(() =>
                {
                    Entity target = currentTarget.Value;

                    if (target == null)
                        return false;

                    float angleToTarget = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(target.Transform.position - transform.position));
                    return angleToTarget < 5f;
                }));

            ReactiveVariable<bool> inAttackProcess = entity.InAttackProcess;

            FuncCondition attackToRotateStateCondition = new FuncCondition(() => inAttackProcess.Value == false);

            AIStateMachine stateMachine = new AIStateMachine();

            stateMachine.AddState(rotateToTargetState);
            stateMachine.AddState(attackRepeatState);

            stateMachine.AddTransition(rotateToTargetState, attackRepeatState, rotateToAttackStateCondition);
            stateMachine.AddTransition(attackRepeatState,rotateToTargetState,attackToRotateStateCondition);

            return stateMachine;
        }

        public StateMachineBrain CreateWalkingRangeEntityBrain(Entity entity)
        {
            TowerHolderService towerHolderService = _container.Resolve<TowerHolderService>();

            FindTowerState findTargetState = new FindTowerState(entity, towerHolderService);

            AIStateMachine behaviour = CreateRangeWalkingEntityCombatStateMachine(entity, towerHolderService);

            AIParallelState parallelState = new AIParallelState(findTargetState, behaviour);

            AIStateMachine rootStateMachine = new AIStateMachine();
            rootStateMachine.AddState(parallelState);

            StateMachineBrain brain = new StateMachineBrain(rootStateMachine);

            _brainsContext.SetFor(entity, brain);

            return brain;
        }

        private AIStateMachine CreateRangeWalkingEntityCombatStateMachine(Entity entity,TowerHolderService towerHolderService)
        {
            MoveToTargetState moveToTargetState = new MoveToTargetState(entity);
            AttackRepeatState attackRepeatState = new AttackRepeatState(entity);
            
            ReactiveVariable<float> attackRange = entity.AttackRange;

            FuncCondition moveToAttackCondition = new FuncCondition(() =>
            {
                if (towerHolderService.Tower.IsDead.Value == false)
                {
                    Vector3 entityPosition = new Vector3(entity.Transform.position.x, 0, entity.Transform.position.z);

                    float attackDistance = attackRange.Value + TowerHolderService.TowerColliderRadius;

                    return ((towerHolderService.Tower.Transform.position - entityPosition).magnitude < attackDistance);
                }

                return false;
            });

            AIStateMachine stateMachine = new AIStateMachine();

            stateMachine.AddState(moveToTargetState);
            stateMachine.AddState(attackRepeatState);

            stateMachine.AddTransition(moveToTargetState,attackRepeatState,moveToAttackCondition);

            return stateMachine;
        }

        public StateMachineBrain CreateWalkingGhostBrain(Entity entity)
        {
            TowerHolderService towerHolderService = _container.Resolve<TowerHolderService>();

            FindTowerState findTargetState = new FindTowerState(entity, towerHolderService);

            AIStateMachine behaviour = CreateMoveToTargetStateMachine(entity, towerHolderService);

            AIParallelState parallelState = new AIParallelState(findTargetState, behaviour);

            AIStateMachine rootStateMachine = new AIStateMachine();
            rootStateMachine.AddState(parallelState);

            StateMachineBrain brain = new StateMachineBrain(rootStateMachine);
            _brainsContext.SetFor(entity, brain);
            return brain;
        }

        private AIStateMachine CreateMoveToTargetStateMachine(Entity entity, TowerHolderService towerHolderService)
        {
            MoveToTargetState moveToTargetState = new MoveToTargetState(entity);
            ExplodeState explodeState = new ExplodeState(entity);

            FuncCondition moveToExplodeCondition = new FuncCondition(() =>
                {
                    if (towerHolderService.Tower.IsDead.Value == false)
                    {
                        Vector3 entityPosition = new Vector3(entity.Transform.position.x, 0, entity.Transform.position.z);

                        return ((towerHolderService.Tower.Transform.position - entityPosition).magnitude < TowerHolderService.TowerColliderRadius);
                    }

                    return false;
                });

            AIStateMachine stateMachine = new AIStateMachine();

            stateMachine.AddState(moveToTargetState);
            stateMachine.AddState(explodeState);

            stateMachine.AddTransition(moveToTargetState, explodeState, moveToExplodeCondition);

            return stateMachine;
        }
    }
}