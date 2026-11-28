using Assets._Project.Ecs.Gameplay.States;
using System;

namespace Assets._Project.Ecs.Gameplay.Features.AI.States
{
    public class GameplayStatesContext : IDisposable
    {
        private GameplayStateMachine _gameplayStateMachine;
        private bool _isRunning;

        public GameplayStatesContext(GameplayStateMachine gameplayStateMachine)
        {
            _gameplayStateMachine = gameplayStateMachine;
        }

        public void Dispose()
        {
            _isRunning = false;
            _gameplayStateMachine.Exit();
            _gameplayStateMachine.Dispose();
        }

        public void Run()
        {
            _gameplayStateMachine.Enter();
            _isRunning = true;
        }

        public void Update(float deltaTime)
        {
            if (_isRunning == false)
                return;

            _gameplayStateMachine.Update(deltaTime);
        }
    }
}