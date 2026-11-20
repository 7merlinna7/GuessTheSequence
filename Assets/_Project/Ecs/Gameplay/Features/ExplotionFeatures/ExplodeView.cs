using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Mono;
using System;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.ExplotionFeatures
{
    [RequireComponent(typeof(Animator))]
    public class ExplodeView : EntityView
    {
        private readonly int IsExplodeKey = Animator.StringToHash("IsDead");

        [SerializeField] private Animator _animator;

        private IReadonlyVariable<bool> _isExplode;

        private IDisposable _isExplodeChangedDisposable;

        private void OnValidate()
        {
            _animator ??= GetComponent<Animator>();
        }

        protected override void OnEntityStartedWork(Entity entity)
        {
            _isExplode = entity.IsExplode;

            _isExplodeChangedDisposable = _isExplode.Subscribe(OnIsMovingChanged);
            UpdateIsExplode(_isExplode.Value);
        }

        public override void Cleanup(Entity entity)
        {
            base.Cleanup(entity);

            _isExplodeChangedDisposable?.Dispose();
        }

        private void UpdateIsExplode(bool value) => _animator.SetBool(IsExplodeKey, value);

        private void OnIsMovingChanged(bool oldIsExplode, bool isExplode) => UpdateIsExplode(isExplode);
    }
}