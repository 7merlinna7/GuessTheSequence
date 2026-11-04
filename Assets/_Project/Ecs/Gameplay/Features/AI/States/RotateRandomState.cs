using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.AI.States
{
    public class RotateRandomState : State, IUpdatableState
    {
        private ReactiveVariable<Vector3> _rotationDirection;
        private ReactiveVariable<float> _teleportationRadius;

        private Vector3 _randomDirection;

        private bool _inRotateprocess;
        public bool InRotateProcess => _inRotateprocess;

        private Transform _transform;

        public RotateRandomState(Entity entity)
        {
            _rotationDirection = entity.RotationDirection;
            _teleportationRadius = entity.TeleprtationRadius;
            _transform = entity.Transform;
        }

        public override void Enter()
        {
            base.Enter();

            RotateToRandomDirection();
        }

        public void Update(float deltaTime)
        {
            _rotationDirection.Value = _randomDirection;
        }

        private void RotateToRandomDirection()
        {
            _inRotateprocess = true;

            Vector2 rand = Random.insideUnitCircle * _teleportationRadius.Value;
            _randomDirection = new Vector3(rand.x, 0, rand.y);
            
            _inRotateprocess = false;
        }
    }
}