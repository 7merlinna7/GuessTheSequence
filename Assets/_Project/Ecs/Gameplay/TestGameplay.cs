using Assets._Project.Develop.Runtime.Configs.Entities;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.AI;
using Assets._Project.Ecs.Gameplay.Features.Enemies;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay
{
    public class TestGameplay 
    {
        private GhostConfig _ghostConfig;

        private EnemiesFactory _enemiesFactory;
        private EntitiesFactory _entitiesFactory;

        private bool _isRunning;

        private BrainsFactory _brainsFactory;

        public void Initialize(DIContainer container,GhostConfig ghostConfig)
        {
            _entitiesFactory = container.Resolve<EntitiesFactory>();
            _brainsFactory = container.Resolve<BrainsFactory>();
            _enemiesFactory = container.Resolve<EnemiesFactory>();
            _ghostConfig = ghostConfig;
        }

        public void Start()
        {
            Debug.Log("Start");
            _entitiesFactory.CreateTower(Vector3.zero, 100);
            _enemiesFactory.Create(Vector3.zero + Vector3.forward * 5, _ghostConfig);
        }

        public void Update()
        {
            if (_isRunning == false)
                return;
        }

    }
}