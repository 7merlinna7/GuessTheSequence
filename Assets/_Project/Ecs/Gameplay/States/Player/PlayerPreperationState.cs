using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.InputFeature;
using Assets._Project.Ecs.Gameplay.Features.InputFeature.RaycastFeature;

namespace Assets._Project.Ecs.Gameplay.States.Player
{
    public class PlayerPreperationState : PlayerGameplayState,IUpdatableState
    {
        public PlayerPreperationState(EntitiesFactory entitiesFactory, PlayerGameplayRayShooter rayShooter, PlayerInput playerInput) : base(entitiesFactory, rayShooter, playerInput)
        {
        }
        protected override void OnMouseButtonClicked()
        {
            _entitiesFactory.CreateBomb(_rayShooter.Shoot(), _playerTeam, 3f, 100f);
        }
    }
}