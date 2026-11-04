using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.AI.States
{
    public class RotateToTargetState : State, IUpdatableState
    {
        private ReactiveVariable<Vector3> _rotationDirection;
        private ReactiveVariable<Entity> _currentTarget;
        private Transform _transform;

        private bool _inRotateProcess;
        public bool InRotateProcess => _inRotateProcess;

        public RotateToTargetState(Entity entity)
        {
            _rotationDirection = entity.RotationDirection;
            _currentTarget = entity.CurrentTarget;
            _transform = entity.Transform;

            _inRotateProcess = true;
        }

        public void Update(float deltaTime)
        {
            _inRotateProcess = true;

            if (_currentTarget.Value != null)
                _rotationDirection.Value = (_currentTarget.Value.Transform.position - _transform.position).normalized;

            _inRotateProcess = false;
        }
    }
}