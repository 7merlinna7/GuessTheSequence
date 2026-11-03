using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using UnityEngine;


namespace Assets._Project.Ecs.Gameplay.Features.AI.States
{
    public class TeleportationState : State, IUpdatableState
    {
        private ReactiveEvent<Vector3> _teleportRequest;

        private ReactiveVariable<float> _teleportationRadius;
        private ReactiveVariable<Vector3> _rotationDirection;

        public TeleportationState(Entity entity)
        {
            _teleportRequest = entity.TeleportRequest;
            _teleportationRadius = entity.TeleprtationRadius;
            _rotationDirection = entity.RotationDirection;
        }

        public override void Enter()
        {
            base.Enter();

            Teleport();
        }


        public void Update(float deltaTime)
        {
            
        }

        private void Teleport()
        {
            Vector3 direction = _rotationDirection.Value * _teleportationRadius.Value;
            _teleportRequest?.Invoke(direction);
        }
    }
}