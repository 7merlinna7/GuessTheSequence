using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Systems;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.MovementFeatures
{
    public class CharacterControllerRotationSystem : IInitializableSystem, IUpdatableSystem
    {

        private ReactiveVariable<Vector3> _direction;
        private ReactiveVariable<float> _rotationSpeed;
        private Transform _transform;

        public void OnInit(Entity entity)
        {
            _rotationSpeed = entity.RotationSpeed;
            _direction = entity.RotationDirection;
            _transform = entity.Transform;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_direction.Value == Vector3.zero)
                return;

            Quaternion lookRotation = Quaternion.LookRotation(_direction.Value.normalized);

            float step = _rotationSpeed.Value * deltaTime;

            Quaternion rotation = Quaternion.RotateTowards(_transform.rotation, lookRotation, step);
            _transform.rotation = rotation;
        }
    }
}