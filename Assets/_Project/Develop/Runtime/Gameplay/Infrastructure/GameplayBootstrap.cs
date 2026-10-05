using Assets._Project.Develop.Runtime.Configs.Gameplay.SequenceConfigs;
using Assets._Project.Develop.Runtime.Gameplay.GamemodeFeature;
using Assets._Project.Develop.Runtime.Gameplay.SequenceFeature;
using Assets._Project.Develop.Runtime.Infrastructure;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilites.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilities.Configs.Gameplay.SequenceConfigs;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using System;
using System.Collections;

namespace Assets._Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayBootstrap : SceneBootstrap
    {
        private DIContainer _container;
        private GameplayInputArgs _inputArgs;
        private GameCycle _gameCycle;

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
            _gameCycle = _container.Resolve<GameCycle>();
            yield break;
        }

        public override void Run()
        {
            _gameCycle.Start();
        }

        private void Update()
        {
            _gameCycle?.Update();
        }

    }
}