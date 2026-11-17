using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.InputFeature;
using Assets._Project.Ecs.Gameplay.Features.InputFeature.RaycastFeature;
using Assets._Project.Ecs.Gameplay.Features.TeamsFeature;

namespace Assets._Project.Ecs.Gameplay.States.Player
{
    public class PlayerAttackState : PlayerGameplayState
    {
        private Teams playerTeam = Teams.Player;
        public PlayerAttackState(EntitiesFactory entitiesFactory, PlayerGameplayRayShooter rayShooter, PlayerInput playerInput) : base(entitiesFactory, rayShooter, playerInput)
        {
        }

        protected override void OnMouseButtonClicked()
        {
            _entitiesFactory.CreateExplotion(_rayShooter.Shoot(), playerTeam,3f,100f);
        }
    }
}