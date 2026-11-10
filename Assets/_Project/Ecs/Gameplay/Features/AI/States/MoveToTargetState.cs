using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.AI.States
{
    public class MoveToTargetState : State, IUpdatableState
    {
        private ReactiveVariable<Vector3> _moveDirection;
        private ReactiveVariable<Vector3> _rotationDirection;
        private Transform _source;
        private Entity _currentTarget;

        public MoveToTargetState(Entity entity)
        {
            _moveDirection = entity.MoveDirection;
            _rotationDirection = entity.RotationDirection;

            _source = entity.Transform;
            _currentTarget = entity.CurrentTarget.Value;
        }

        public void Update(float deltaTime)
        {
            Vector3 direction = (_currentTarget.Transform.position - _source.position).normalized;

            _rotationDirection.Value = direction;
            _moveDirection.Value = direction;
        }
    }
}