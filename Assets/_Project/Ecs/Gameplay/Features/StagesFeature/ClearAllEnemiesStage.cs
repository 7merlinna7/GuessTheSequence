using Assets._Project.Develop.Runtime.Configs.Gameplay.Stages;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.Enemies;
using System;
using System.Collections.Generic;

namespace Assets._Project.Ecs.Gameplay.Features.StagesFeature
{
    public class ClearAllEnemiesStage : IStage
    {
        private ClearAllEnemiesStageConfig _config;

        private ReactiveEvent _completed = new();

        private EnemiesFactory _enemiesFactory;
        private EntitiesLifeContext _entitiesLifeContext;

        private bool _inProcess;

        private Dictionary<Entity, IDisposable> _spawnEnemiesToRemoveReason = new();

        public IReadonlyEvent Completed => _completed;

        public ClearAllEnemiesStage(
            ClearAllEnemiesStageConfig config,
            EnemiesFactory enemiesFactory,
            EntitiesLifeContext entitiesLifeContext)
        {
            _config = config;
            _enemiesFactory = enemiesFactory;
            _entitiesLifeContext = entitiesLifeContext;
        }

        public void CleanUp()
        {
            foreach (KeyValuePair<Entity, IDisposable> item in _spawnEnemiesToRemoveReason)
            {
                item.Value.Dispose();
                _entitiesLifeContext.Release(item.Key);
            }

            _spawnEnemiesToRemoveReason.Clear();
            _inProcess = false;
        }

        public void Dispose()
        {
            foreach (KeyValuePair<Entity, IDisposable> item in _spawnEnemiesToRemoveReason)
            {
                item.Value.Dispose();
            }

            _spawnEnemiesToRemoveReason.Clear();
            _inProcess = false;
        }

        public void Start()
        {
            if (_inProcess)
                throw new InvalidOperationException("Gamemode is already started");

            SpawnEnemies();

            _inProcess = true;
        }

        public void Update(float deltaTime)
        {
            if (_inProcess == false)
                return;

            if (_spawnEnemiesToRemoveReason.Count == 0)
                ProcessEnd();
        }

        private void SpawnEnemies()
        {
            foreach (EnemyItemConfig enemyItemConfig in _config.EnemyItems)
                SpawnEnemy(enemyItemConfig);
        }


        private void SpawnEnemy(EnemyItemConfig enemyItemConfig)
        {
            Entity spawnedEnemy = _enemiesFactory.Create(enemyItemConfig.SpawnPosition,enemyItemConfig.EnemyConfig);
            IDisposable removeReason = spawnedEnemy.IsDead.Subscribe((oldValue, IsDead) =>
            {
                if(IsDead)
                {
                    IDisposable disposable = _spawnEnemiesToRemoveReason[spawnedEnemy];
                    disposable.Dispose();
                    _spawnEnemiesToRemoveReason.Remove(spawnedEnemy);
                }
            });

            _spawnEnemiesToRemoveReason.Add(spawnedEnemy,removeReason);
        }

        private void ProcessEnd()
        {
            _inProcess = false;
            _completed.Invoke();
        }
    }
}