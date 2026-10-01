using Assets._Project.Develop.Runtime.Gameplay.GamemodeFeature;
using Assets._Project.Develop.Runtime.Gameplay.SequenceFeature;
using Assets._Project.Develop.Runtime.Infrastructure;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilites.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilites.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.Configs;
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
            SequenceFactory sequenceFactory = new SequenceFactory(GetSequenceConfig(_container));
            Gamemode gamemode = new Gamemode(sequenceFactory.Create());

            _gameCycle = new GameCycle(_container.Resolve<ICoroutinesPerformer>(),_container.Resolve<SceneSwitcherService>(),gamemode);
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

        private ISequenceConfig GetSequenceConfig(DIContainer container)
        {
            ISequenceConfig config = null;
            switch (_inputArgs.LevelType)
            {
                case SequenceType.Letters:
                    config = _container.Resolve<ConfigsProviderService>().GetConfig<LettersSequenceConfig>();
                    break;
                case SequenceType.Numbers:
                    config = _container.Resolve<ConfigsProviderService>().GetConfig<NumbersSequenceConfig>();
                    break;
            }
            return config;
        }
    }
}