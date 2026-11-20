using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Mono;
using System;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.LifeCycle
{
    [RequireComponent(typeof(Animator))]
    public class DeadView : EntityView
    {
        private readonly int IsDeadKey = Animator.StringToHash("IsDead");

        [SerializeField] private Animator _animator;

        private IReadonlyVariable<bool> _isDead;

        private IDisposable _isDeadChangedDisposable;

        private void OnValidate()
        {
            _animator ??= GetComponent<Animator>();
        }

        protected override void OnEntityStartedWork(Entity entity)
        {
            _isDead = entity.IsDead;

            _isDeadChangedDisposable = _isDead.Subscribe(OnIsMovingChanged);
            UpdateIsDead(_isDead.Value);
        }

        public override void Cleanup(Entity entity)
        {
            base.Cleanup(entity);

            _isDeadChangedDisposable?.Dispose();
        }

        private void UpdateIsDead(bool value) => _animator.SetBool(IsDeadKey, value);

        private void OnIsMovingChanged(bool oldIsDead, bool isDead) => UpdateIsDead(isDead);
    }
}