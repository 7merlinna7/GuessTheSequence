using Assets._Project.Develop.Runtime.Meta.Features;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using Assets._Project.Ecs.Gameplay.Features.InputFeature;
using Assets._Project.Ecs.Gameplay.Features.InputFeature.RaycastFeature;
using Assets._Project.Ecs.Gameplay.Features.Player;

namespace Assets._Project.Ecs.Gameplay.States.Player
{
    public class PlayerPreperationState : PlayerGameplayState,IUpdatableState
    {
        private readonly PurchaseChecker _purchaseChecker;

        public PlayerPreperationState(
            PlayerGameplayAbilitiesFactory playerAbilitiesFactory,
            PlayerGameplayRayShooter rayShooter,
            PlayerInput playerInput,
            PurchaseChecker purchaseChecker) : base(playerAbilitiesFactory, rayShooter, playerInput)
        {
            _purchaseChecker = purchaseChecker;
        }
        protected override void OnMouseButtonClicked()
        {
            _playerAbilitiesFactory.CreateDamageArea(_rayShooter.Shoot());
        }
    }
}