using Assets._Project.Develop.Runtime.Infrastructure;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilites.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenuBootstrap : SceneBootstrap
    {
        private DIContainer _container;
        private MainMenu _mainMenu;

        public override void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            MainMenueContextRegistrations.Process(_container);
        }

        public override IEnumerator Initialize()
        {
            _mainMenu = _container.Resolve<MainMenu>();

            yield break;
        }

        public override void Run()
        {
            _mainMenu.Start(_container.Resolve<SceneSwitcherService>(),_container.Resolve<ICoroutinesPerformer>());
        }
    }
}