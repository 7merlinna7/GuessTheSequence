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
        private GhostConfig _ghostConfig;

        private EnemiesFactory _enemiesFactory;

        private EntitiesFactory _entitiesFactory;
        private Entity _entity;
        private Entity _ghost;
        private Entity _teleportingGhost;
        private bool _isRunning;

        private BrainsFactory _brainsFactory;

        public void Initialize(DIContainer container, GhostConfig ghost)
        {
            _entitiesFactory = container.Resolve<EntitiesFactory>();
            _brainsFactory = container.Resolve<BrainsFactory>();
            _enemiesFactory = container.Resolve<EnemiesFactory>();

            _ghostConfig = ghost;
        }

        public void Start()
        {

        }

        public void Update()
        {
            if (_isRunning == false)
                return;
        }

    }
}