using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Systems;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.MovementFeatures
{
    public class MovementSystem : IInitializableSystem, IUpdatableSystem
    {
        ReactiveVariable<Vector3> _moveDirection;
        ReactiveVariable<float> _moveSpeed;

        public void OnInit(Entity entity)
        {
            _moveDirection = entity.GetComponent<MoveDirection>().Value;
            _moveSpeed = entity.GetComponent<MoveSpeed>().Value;
        }

        public void OnUpdate(float deltaTime)
        {
            Vector3 velocity = _moveDirection.Value.normalized * _moveSpeed.Value;
        }
    }
}