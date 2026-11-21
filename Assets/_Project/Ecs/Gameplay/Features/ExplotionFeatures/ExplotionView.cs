using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Mono;
using System;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.ExplotionFeatures
{
    public class ExplotionView : EntityView
    {
        [SerializeField] private ParticleSystem _explotionEffectPrefab;
        [SerializeField] private Transform _effectSpawnPoint;

        private ReactiveEvent _explotionEvent;

        private IDisposable _explotionEventDisposable;

        protected override void OnEntityStartedWork(Entity entity)
        {
            _explotionEvent = entity.DealExplotionDamageEvent;
            _explotionEventDisposable = _explotionEvent.Subscribe(OnExplode);
        }

        public override void Cleanup(Entity entity)
        {
            base.Cleanup(entity);

            _explotionEventDisposable.Dispose();
        }

        private void OnExplode()
        {
            Instantiate(_explotionEffectPrefab, _effectSpawnPoint.position, Quaternion.identity);
        }
    }
}