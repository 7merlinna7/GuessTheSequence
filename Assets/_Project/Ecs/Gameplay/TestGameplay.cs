using Assets._Project.Develop.Runtime.Configs.Entities;
using Assets._Project.Develop.Runtime.Configs.Gameplay.Stages;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.AI;
using Assets._Project.Ecs.Gameplay.Features.Enemies;
using Assets._Project.Ecs.Gameplay.Features.StagesFeature;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay
{
    public class TestGameplay 
    {
        private StageConfig _stageConfig;

        private EnemiesFactory _enemiesFactory;
        private EntitiesFactory _entitiesFactory;
        private StagesFactory _stagesFactory;
        private IStage _stage;

        private bool _isRunning;

        public void Initialize(DIContainer container, StageConfig stageConfig)
        {
            _entitiesFactory = container.Resolve<EntitiesFactory>();
            _enemiesFactory = container.Resolve<EnemiesFactory>();
            _stageConfig = stageConfig;
            _stagesFactory = container.Resolve<StagesFactory>();
        }

        public void Start()
        {
            _stage = _stagesFactory.Create(_stageConfig);
            _stage.Start();

            _isRunning = true;

            //Debug.Log("Start");
            //_entitiesFactory.CreateTower(Vector3.zero, 100);
            //_enemiesFactory.Create(Vector3.zero + Vector3.forward * 5, _ghostConfig);
            //_enemiesFactory.Create(Vector3.zero + Vector3.forward * 8, _ghostConfig);
        }

        public void Update()
        {
            if (_isRunning == false)
                return;

            _stage.Update(Time.deltaTime);
        }

    }
}