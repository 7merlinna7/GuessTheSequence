using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using Assets._Project.Ecs.Gameplay.Features.InputFeature;
using Assets._Project.Ecs.Gameplay.Features.InputFeature.RaycastFeature;
using Assets._Project.Ecs.Gameplay.Features.Player;

namespace Assets._Project.Ecs.Gameplay.States.Player
{
    public class PlayerAttackState : PlayerGameplayState ,IUpdatableState
    {
        public PlayerAttackState(
            PlayerGameplayAbilitiesFactory playerAbilitiesFactory,
            PlayerGameplayRayShooter rayShooter,
            PlayerInput playerInput) : base(playerAbilitiesFactory, rayShooter, playerInput)
        {
        }

        protected override void OnMouseButtonClicked()
        {
            _playerAbilitiesFactory.CreateExplotion(_rayShooter.Shoot());
        }
    }
}