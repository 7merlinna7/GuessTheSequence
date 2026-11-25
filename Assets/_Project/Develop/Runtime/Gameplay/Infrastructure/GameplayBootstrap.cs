using Assets._Project.Develop.Runtime.Configs.Entities;
using Assets._Project.Develop.Runtime.Configs.Gameplay.Levels;
using Assets._Project.Develop.Runtime.Configs.Gameplay.Stages;
using Assets._Project.Develop.Runtime.Infrastructure;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.UI.Gameplay;
using Assets._Project.Develop.Runtime.Utilites.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using Assets._Project.Ecs.Gameplay;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.AI;
using Assets._Project.Ecs.Gameplay.Features.AI.States;
using System;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayBootstrap : SceneBootstrap
    {
        private DIContainer _container;
        private GameplayInputArgs _inputArgs;

        private GameplayStatesContext _gameplayStatesContext;
        private bool _isRunning;
        private EntitiesLifeContext _lifeContext;
        private AIBrainsContext _brainsContext;

        private GameplayScreenPresenter _screenPresenter;


        public override void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            if (sceneArgs is not GameplayInputArgs gameplayInputArgs)
                throw new ArgumentException($"{nameof(sceneArgs)} is not match with {typeof(GameplayInputArgs)} type.");

            _inputArgs = gameplayInputArgs;

            GameplayContextRegistrations.Process(_container, _inputArgs);

        }

        public override IEnumerator Initialize()
        {
            _gameplayStatesContext = _container.Resolve<GameplayStatesContext>();
            _lifeContext = _container.Resolve<EntitiesLifeContext>();
            _brainsContext = _container.Resolve<AIBrainsContext>();

            _screenPresenter = _container.Resolve<GameplayScreenPresenter>();

            LevelConfig levelConfig = _container.Resolve<ConfigsProviderService>().GetConfig<LevelListConfig>().GetBy(_inputArgs.LevelNumber);

            _container.Resolve<EntitiesFactory>().CreateTower(Vector3.zero,levelConfig.TowerMaxHealth);

            yield break;
        }

        public override void Run()
        {
            _gameplayStatesContext.Run();
            Debug.Log("Level number "+ _inputArgs.LevelNumber);
            _isRunning = true;
        }

        private void Update()
        {
            if (_isRunning == false)
                return;

            _brainsContext?.Update(Time.deltaTime);
            _lifeContext?.Update(Time.deltaTime);
            _gameplayStatesContext?.Update(Time.deltaTime);
        }

        private void LateUpdate()
        {
            _screenPresenter?.LateUpdate();
        }
    }
}