using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Systems;
using Assets._Project.Ecs.Utilities.Conditions;
using System;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.AplyDamage
{
    public class ApplyDamageSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent<float> _damageRequest;
        private ReactiveEvent<float> _damageEvent;

        private ReactiveVariable<float> _health;

        private ICompositeCondition _canApplyDamage;

        private IDisposable _requestDisposable;

        public void OnInit(Entity entity)
        {
            _damageRequest = entity.TakeDamageRequest;
            _damageEvent = entity.TakeDamageEvent;

            _health = entity.CurrentHealth;

            _canApplyDamage = entity.CanApplayDamage;

            _requestDisposable = _damageRequest.Subscribe(OnDamageRequest);
        }
        public void OnDispose()
        {
            _requestDisposable.Dispose();
        }

        private void OnDamageRequest(float damage)
        {
            if(damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            if (_canApplyDamage.Evaluate() == false)
                return;

            _health.Value = MathF.Max(_health.Value - damage, 0);
            _damageEvent.Invoke(damage);
        }
    }
}