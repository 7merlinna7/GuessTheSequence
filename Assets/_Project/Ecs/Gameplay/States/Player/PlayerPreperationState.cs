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
        private readonly BrainsFactory _brainsFactory;

        public PlayerPreperationState(
            EntitiesFactory entitiesFactory,
            PlayerGameplayRayShooter rayShooter,
            PlayerInput playerInput,
            PurchaseChecker purchaseChecker,
            BrainsFactory brainsFactory) : base(entitiesFactory, rayShooter, playerInput)
        {
            _purchaseChecker = purchaseChecker;
            _brainsFactory = brainsFactory;
        }
        protected override void OnMouseButtonClicked()
        {
            Entity entity = _entitiesFactory.CreateDamageArea(_rayShooter.Shoot(),10f,Features.TeamsFeature.Teams.Player);

            //_brainsFactory.CreateStayingRangeEntityBrain(entity);

            //if (_purchaseChecker.GetBomb())
            //_entitiesFactory.CreateBomb(_rayShooter.Shoot(), _playerTeam, 1f, 100f);
        }
    }
}