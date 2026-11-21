using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Mono;
using System;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.AplyDamage
{
    public class ApplyDamageView : EntityView
    {
        [SerializeField] private ParticleSystem _applayDamageEffectPrefab;
        [SerializeField] private Transform _effectSpawnPoint;

        private ReactiveEvent<float> _damageEvent;

        private IDisposable _damageEventDisposable;

        protected override void OnEntityStartedWork(Entity entity)
        {
            _damageEvent = entity.TakeDamageEvent;
            _damageEventDisposable = _damageEvent.Subscribe(OnDamaged);
        }

        public override void Cleanup(Entity entity)
        {
            base.Cleanup(entity);

            _damageEventDisposable.Dispose();
        }

        private void OnDamaged(float obj)
        {
            Instantiate(_applayDamageEffectPrefab,_effectSpawnPoint.position,Quaternion.identity);
        }
    }
}