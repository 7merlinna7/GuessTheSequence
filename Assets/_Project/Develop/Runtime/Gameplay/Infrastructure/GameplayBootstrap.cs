using Assets._Project.Develop.Runtime.Infrastructure;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using Assets._Project.Ecs.Gameplay;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using System;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayBootstrap : SceneBootstrap
    {
        private DIContainer _container;
        private GameplayInputArgs _inputArgs;
        private TestGameplay _testGameplay;
        private bool _isRunning;
        private EntitiesLifeContext _lifeContext;


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
            _testGameplay = new TestGameplay(_container.Resolve<EntitiesFactory>());
            _lifeContext = _container.Resolve<EntitiesLifeContext>();

            yield break;
        }

        public override void Run()
        {
            _testGameplay.Start(_inputArgs.LevelType);
            _isRunning = true;
        }

        private void Update()
        {
            if (_isRunning == false)
                return;
            
            _testGameplay.Update();
            _lifeContext?.Update(Time.deltaTime);
        }

    }
}