using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Develop.Runtime.Utilities.Timer;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.AI.States;
using Assets._Project.Ecs.Gameplay.Features.AI.States.TargetSelectors;
using Assets._Project.Ecs.Gameplay.Features.TowerFeature;
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
        private readonly EntitiesLifeContext _entitiesLifeContext;

        public BrainsFactory(DIContainer container)
        {
            _container = container;
            _timerServiceFactory = _container.Resolve<TimerServiceFactory>();
            _brainsContext = _container.Resolve<AIBrainsContext>();
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
        }

        public StateMachineBrain CreateWalkingGhostBrain(Entity entity,ITargetSelector targetSelector)
        {
            FindTargetState findTargetState = new FindTargetState(targetSelector, _entitiesLifeContext, entity);

            AIStateMachine behaviour = CreateMoveToTargetStateMachine(entity,targetSelector);

            AIParallelState parallelState = new AIParallelState(findTargetState, behaviour);

            AIStateMachine rootStateMachine = new AIStateMachine();
            rootStateMachine.AddState(parallelState);

            StateMachineBrain brain = new StateMachineBrain(rootStateMachine);
            _brainsContext.SetFor(entity, brain);
            return brain;
        }

        private AIStateMachine CreateMoveToTargetStateMachine(Entity entity,ITargetSelector targetSelector)
        {
            MoveToTargetState moveToTargetState = new MoveToTargetState(entity);
            ExplodeState explodeState = new ExplodeState(entity);

            ReactiveVariable <Entity> currentTarget = entity.CurrentTarget;

            FuncCondition moveToExplodeCondition = new FuncCondition(()=> (currentTarget.Value.Transform.position - entity.Transform.position).magnitude < 1.5f);

            AIStateMachine stateMachine = new AIStateMachine();

            stateMachine.AddState(moveToTargetState);
            stateMachine.AddState(explodeState);

            stateMachine.AddTransition(moveToTargetState, explodeState, moveToExplodeCondition);

            return stateMachine;
        }
    }
}