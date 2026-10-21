using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Systems;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.LifeCycle
{
    public class DeathSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<float> _currentHealth;
        private ReactiveVariable<bool> _isDead;

        public void OnInit(Entity entity)
        {
            _isDead = entity.IsDead;
            _currentHealth = entity.CurrentHealth;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_isDead.Value)
                return;

            if (_currentHealth.Value<= 0)
            {
                _isDead.Value = true;
                Debug.Log("Dead");
            }
        }
    }
}