using Assets._Project.Develop.Runtime.Configs.Entities;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.AI;
using Assets._Project.Ecs.Gameplay.Features.AI.States;
using Assets._Project.Ecs.Gameplay.Features.Enemies;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay
{
    public class TestGameplay 
    {
        private HeroConfig _heroConfig;
        private GhostConfig _ghostConfig;

        private EnemiesFactory _enemiesFactory;

        private EntitiesFactory _entitiesFactory;
        private Entity _entity;
        private Entity _ghost;
        private Entity _teleportingGhost;
        private bool _isRunning;

        private BrainsFactory _brainsFactory;

        public void Initialize(DIContainer container,HeroConfig hero, GhostConfig ghost)
        {
            _entitiesFactory = container.Resolve<EntitiesFactory>();
            _brainsFactory = container.Resolve<BrainsFactory>();
            _enemiesFactory = container.Resolve<EnemiesFactory>();

            _heroConfig = hero;
            _ghostConfig = ghost;
        }

        public void Start(SequenceType sequenceType)
        {
            if (sequenceType == SequenceType.Numbers)
            {
                _entity = _entitiesFactory.CreateHero(Vector3.zero,_heroConfig);
                _entity.AddCurrentTarget();
                _brainsFactory.CreateMainHeroBrain(_entity, new NearestDamagebleTargetSelector(_entity));

                _ghost = _enemiesFactory.Create(Vector3.zero + Vector3.forward * 6 + Vector3.left * 2, _ghostConfig);
            }

            if (sequenceType == SequenceType.Letters)
            {
                _entitiesFactory.CreateWalkingGhost(Vector3.zero + Vector3.forward * 6 + Vector3.left * 2,_ghostConfig);
                _entitiesFactory.CreateWalkingGhost(Vector3.zero + Vector3.forward * 6 + Vector3.right * 2, _ghostConfig);

                _teleportingGhost = _entitiesFactory.CreateTeleportingGhost(Vector3.zero);
                _teleportingGhost.AddCurrentTarget();
                _brainsFactory.CreateSmartTeleportingGhostBrain(_teleportingGhost, new MinHealthTargetSelector(_entity));
            }

            _isRunning = true;
        }

        public void Update()
        {
            if (_isRunning == false)
                return;
        }

    }
}