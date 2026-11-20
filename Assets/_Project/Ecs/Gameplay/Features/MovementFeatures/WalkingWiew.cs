using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Mono;
using System;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.MovementFeatures
{
    [RequireComponent(typeof(Animator))]

    public class WalkingWiew : EntityView
    {
        private readonly int IsMovingKey = Animator.StringToHash("IsMoving");

        [SerializeField] private Animator _animator;

        private IReadonlyVariable<bool> _isMoving;

        private IDisposable _isMovingChangedDisposable;

        private void OnValidate()
        {
            _animator??=GetComponent<Animator>();
        }

        protected override void OnEntityStartedWork(Entity entity)
        {
            _isMoving = entity.IsMoving;

            _isMovingChangedDisposable = _isMoving.Subscribe(OnIsMovingChanged);
            UpdateIsMoving(_isMoving.Value);
        }

        public override void Cleanup(Entity entity)
        {
            base.Cleanup(entity);

            _isMovingChangedDisposable?.Dispose();
        }

        private void UpdateIsMoving(bool value) => _animator.SetBool(IsMovingKey, value);

        private void OnIsMovingChanged(bool oldIsMoving, bool isMoving) => UpdateIsMoving(isMoving);

    }
}