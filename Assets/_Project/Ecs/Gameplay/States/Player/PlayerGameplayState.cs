using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using Assets._Project.Ecs.Gameplay.Features.InputFeature;
using Assets._Project.Ecs.Gameplay.Features.InputFeature.RaycastFeature;
using Assets._Project.Ecs.Gameplay.Features.Player;
using Assets._Project.Ecs.Gameplay.Features.TeamsFeature;

namespace Assets._Project.Ecs.Gameplay.States.Player
{
    public class PlayerGameplayState : State, IUpdatableState
    {
        protected readonly PlayerGameplayAbilitiesFactory _playerAbilitiesFactory;

        protected PlayerGameplayRayShooter _rayShooter;
        private PlayerInput _playerInput;
        protected Teams _playerTeam = Teams.Player;

        public PlayerGameplayState(
            PlayerGameplayAbilitiesFactory playerAbilitiesFactory,
            PlayerGameplayRayShooter rayShooter,
            PlayerInput playerInput)
        {
            _playerAbilitiesFactory = playerAbilitiesFactory;
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