using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.AI.States;
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

        public StateMachineBrain CreateWalkingGhostBrain(Entity entity)
        {
            TowerHolderService towerHolderService = _container.Resolve<TowerHolderService>();

            FindTargetState findTargetState = new FindTargetState(entity,towerHolderService);

            AIStateMachine behaviour = CreateMoveToTargetStateMachine(entity,towerHolderService);

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
                        Debug.Log((towerHolderService.Tower.Transform.position - entityPosition).magnitude);

                        return ((towerHolderService.Tower.Transform.position - entityPosition).magnitude < 2f);
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