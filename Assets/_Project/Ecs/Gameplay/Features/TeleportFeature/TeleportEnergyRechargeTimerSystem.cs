using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Systems;

namespace Assets._Project.Ecs.Gameplay.Features.TeleportFeature
{
    public class TeleportEnergyRechargeTimerSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<float> _currentTime;
        private ReactiveVariable<float> _maxTime;
        private ReactiveEvent _rechargeEnergyTimerIsOver;

        public void OnInit(Entity entity)
        {
            _currentTime = entity.CurrentTeleportEnergyRechargeTime;
            _maxTime = entity.MaxTeleportEnergyRechargeTime;
            _rechargeEnergyTimerIsOver = entity.RechargeEnergyTimerIsOver;
        }

        public void OnUpdate(float deltaTime)
        {
            _currentTime.Value -= deltaTime;

            if (_currentTime.Value <= 0)
                ResetTimer();
        }

        private void ResetTimer()
        {
            _currentTime.Value = _maxTime.Value;
            _rechargeEnergyTimerIsOver.Invoke();
        }
    }
}