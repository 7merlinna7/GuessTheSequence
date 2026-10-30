using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Systems;
using System;

namespace Assets._Project.Ecs.Gameplay.Features.Attack
{
    public class AttackProcessTimerSystem : IInitializableSystem, IDisposableSystem, IUpdatableSystem
    {
        private ReactiveVariable<float> _currentTime;
        private ReactiveVariable<bool> _InAttackProcess;
        private ReactiveEvent _startAttackEvent;
        private IDisposable _startAttackEventDisposable;


        public void OnInit(Entity entity)
        {
            _currentTime = entity.AttackProcessCurrentTime;
            _InAttackProcess = entity.InAttackProcess;
            _startAttackEvent = entity.StartAttackEvent;

            _startAttackEventDisposable = _startAttackEvent.Subscribe(OnStartAttackProcess);
        }

        private void OnStartAttackProcess()
        {
            _currentTime.Value = 0;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_InAttackProcess.Value == false)
                return;

            _currentTime.Value += deltaTime;
        }

        public void OnDispose()
        {
            _startAttackEventDisposable.Dispose();
        }
    }
}