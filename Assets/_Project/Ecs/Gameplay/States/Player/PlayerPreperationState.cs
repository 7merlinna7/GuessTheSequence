using Assets._Project.Develop.Runtime.Meta.Features;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.AI;
using Assets._Project.Ecs.Gameplay.Features.InputFeature;
using Assets._Project.Ecs.Gameplay.Features.InputFeature.RaycastFeature;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.States.Player
{
    public class PlayerPreperationState : PlayerGameplayState,IUpdatableState
    {
        private readonly PurchaseChecker _purchaseChecker;
        public PlayerPreperationState(
            EntitiesFactory entitiesFactory,
            PlayerGameplayRayShooter rayShooter,
            PlayerInput playerInput,
            PurchaseChecker purchaseChecker) : base(entitiesFactory, rayShooter, playerInput)
        {
            _purchaseChecker = purchaseChecker;
        }
        protected override void OnMouseButtonClicked()
        {
            if (_purchaseChecker.GetBomb())
            _entitiesFactory.CreateBomb(_rayShooter.Shoot(), _playerTeam, 1f, 100f);
        }
    }
}