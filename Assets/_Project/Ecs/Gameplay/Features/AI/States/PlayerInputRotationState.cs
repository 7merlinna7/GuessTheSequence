using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.InputFeature;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.AI.States
{
    public class PlayerInputRotationState : State, IUpdatableState
    {
        private IInputService _inputService;
        private ReactiveVariable<Vector3> _rotationDirection;

        public PlayerInputRotationState(Entity entity,IInputService inputService)
        {
            _rotationDirection = entity.RotationDirection;

            _inputService = inputService;
        }

        public void Update(float deltaTime)
        {
            _rotationDirection.Value = _inputService.Direction;
        }

        public override void Exit()
        {
            base.Exit();

            _rotationDirection.Value = Vector3.zero;
        }
    }
}