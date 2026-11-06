using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Systems;
using Assets._Project.Ecs.Utilities.Conditions;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.MovementFeatures
{
    public class MouseRotationSystem : IInitializableSystem, IUpdatableSystem
    {
        private Rigidbody _rigidbody;
        private ReactiveVariable<float> _rotationSpeed;
        private ReactiveVariable<float> _mouseRotationSpeed;
        private ReactiveVariable<Vector3> _direction;
        private Transform _transform;

        private ICompositeCondition _canRotate;

        public void OnInit(Entity entity)
        {
            _rigidbody = entity.Rigidbody;
            _rotationSpeed = entity.RotationSpeed;
            _mouseRotationSpeed = entity.MouseRotationSpeed;

            _direction = entity.RotationDirection;
            _transform = entity.Transform;

            _canRotate = entity.CanRotate;

            if (_direction.Value != Vector3.zero)
                _rigidbody.transform.rotation = Quaternion.LookRotation(_direction.Value.normalized);
        }

        public void OnUpdate(float deltaTime)
        {
            if (_canRotate.Evaluate() == false)
                return;

            if (_direction.Value == Vector3.zero)
                return;

            if (_direction.Value.y != 0)
            {
                _transform.Rotate(_direction.Value.normalized * _mouseRotationSpeed.Value * deltaTime);
            }
            else
            {
                Quaternion lookRotation = Quaternion.LookRotation(_direction.Value.normalized);

                float step = _rotationSpeed.Value * deltaTime;

                Quaternion rotation = Quaternion.RotateTowards(_rigidbody.rotation, lookRotation, step);

                _rigidbody.MoveRotation(rotation);
            }
        }
    }
}