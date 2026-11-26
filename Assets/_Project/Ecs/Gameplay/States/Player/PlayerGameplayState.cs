using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.InputFeature;
using Assets._Project.Ecs.Gameplay.Features.InputFeature.RaycastFeature;
using Assets._Project.Ecs.Gameplay.Features.TeamsFeature;
using Unity.IO.LowLevel.Unsafe;

namespace Assets._Project.Ecs.Gameplay.States.Player
{
    public class PlayerGameplayState : State, IUpdatableState
    {
        protected readonly EntitiesFactory _entitiesFactory;

        protected PlayerGameplayRayShooter _rayShooter;
        private PlayerInput _playerInput;
        protected Teams _playerTeam = Teams.Player;

        public PlayerGameplayState(
            EntitiesFactory entitiesFactory,
            PlayerGameplayRayShooter rayShooter,
            PlayerInput playerInput)
        {
            _entitiesFactory = entitiesFactory;
            _rayShooter = rayShooter;
            _playerInput = playerInput;
        }

        public void Update(float deltaTime)
        {
            _playerInput.Update(deltaTime);

            if (_playerInput.IsMouseButtonClicked)
            {
                OnMouseButtonClicked();
            }     


        }

        protected virtual void OnMouseButtonClicked()
        {
        }
    }
}