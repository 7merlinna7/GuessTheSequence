using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.AI;
using Assets._Project.Ecs.Gameplay.Features.TeamsFeature;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.Player
{
    public class PlayerGameplayAbilitiesFactory 
    {
        private readonly EntitiesFactory _entitiesFactory;
        private readonly BrainsFactory _brainsFactory;
        private Teams team = Teams.Player;

        public PlayerGameplayAbilitiesFactory(EntitiesFactory entitiesFactory, BrainsFactory brainsFactory)
        {
            _entitiesFactory = entitiesFactory;
            _brainsFactory = brainsFactory;
        }

        public void CreateExplotionAttack (Vector3 position)
        {
            _entitiesFactory.CreateExplotion(position,team,3f,50f);
        }

        public void CreateBobm(Vector3 position)
        {
           _entitiesFactory.CreateBomb(position, team, 1f, 100f);
        }

        public void CreateShootingTower(Vector3 position)
        {
            Entity entity = _entitiesFactory.CreateRangeStayEntity(position,team);
            _brainsFactory.CreateStayingRangeEntityBrain(entity);
        }

        public void CreateDamageArea(Vector3 position)
        {
            _entitiesFactory.CreateDamageArea(position, 10f,team);
        }
    }
}