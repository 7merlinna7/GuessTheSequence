using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.Timer;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.AI.States;
using Assets._Project.Ecs.Utilities.Conditions;
using System;
using System.Collections.Generic;

namespace Assets._Project.Ecs.Gameplay.Features.AI
{
    public class BrainsFactory 
    {
        private readonly DIContainer _container;
        private readonly TimerServiceFactory _timerServiceFactory;
        private readonly AIBrainsContext _brainsContext;

        public BrainsFactory(DIContainer container)
        {
            _container = container;
            _timerServiceFactory = _container.Resolve<TimerServiceFactory>();
            _brainsContext = _container.Resolve<AIBrainsContext>();
        }

        public StateMachineBrain CreateGhostBrain(Entity entity)
        {
            AIStateMachine stateMachine = CreateRandomMovementStateMashine(entity);
            StateMachineBrain brain = new StateMachineBrain(stateMachine);

            _brainsContext.SetFor(entity, brain);

            return brain;
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
    }
}