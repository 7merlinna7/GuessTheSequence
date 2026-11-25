using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.InputFeature;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.AI.States
{
    public class PlayerInputRotationState : State, IUpdatableState
    {
        private PlayerGameplayRayShooter _rayShooter;
        private ReactiveVariable<Vector3> _rotationDirection;
        private Transform _transform;

        public PlayerInputRotationState(Entity entity, PlayerGameplayRayShooter rayShooter)
        {
            _rotationDirection = entity.RotationDirection;
            _transform = entity.Transform;

            _rayShooter = rayShooter;
        }

        public void Update(float deltaTime)
        {
            _rotationDirection.Value = _rayShooter.Shoot() - _transform.position;
        }

        public override void Exit()
        {
            base.Exit();

            _rotationDirection.Value = Vector3.zero;
        }
    }
}