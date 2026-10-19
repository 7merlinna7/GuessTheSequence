using Assets._Project.Develop.Runtime.Infrastructure;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
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

       // private EntitiesFactory _entitiesFactory;

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
           // _entitiesFactory = _container.Resolve<EntitiesFactory>();

            yield break;
        }

        public override void Run()
        {
           // Entity entity = _entitiesFactory.CreateTestEntity(Vector3.zero);
        }

        private void Update()
        {
           
        }

    }
}