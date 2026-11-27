using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Systems;
using Assets._Project.Ecs.Gameplay.Features.ContactTakeDamage;

namespace Assets._Project.Ecs.Gameplay.Features.Sensors
{
    public class BodyContactsResetTimerSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<float> _initialTime;
        private ReactiveVariable<float> _currentTime;

        private readonly DealDamageOnContactSystem _contactSystem;

        public BodyContactsResetTimerSystem(DealDamageOnContactSystem contactSystem)
        {
            _contactSystem = contactSystem;
        }

        public void OnInit(Entity entity)
        {
            _initialTime = entity.DamageDelayInitialTime;
            _currentTime = entity.DamageDelayCurrentTime;

            _currentTime.Value = 0;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_currentTime.Value >= _initialTime.Value)
                ResetTimer();

            _currentTime.Value += deltaTime;
        }

        private void ResetTimer()
        {
            _currentTime.Value = 0;
            _contactSystem.ClearProcessedEntities();
        }
    }
}