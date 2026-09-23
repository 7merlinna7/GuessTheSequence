using Assets._Project.Develop.Runtime.Infrastructure;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.LoadingScreen;
using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets._Project.Develop.Runtime.Utilities.SceneManagment
{
    public class SceneSwitcherService 
    {
        private readonly SceneLoaderService _sceneLoaderService;
        private readonly ILoadingScreen _loadingScreen;
        private readonly DIContainer _container;

        public SceneSwitcherService(
            SceneLoaderService sceneLoaderService,
            ILoadingScreen loadingScreen,
            DIContainer container)
        {
            _sceneLoaderService = sceneLoaderService;
            _loadingScreen = loadingScreen;
            _container = container;
        }

        public IEnumerator ProcessSwitchTo(string sceneName)
        {
            _loadingScreen.Show();

            yield return _sceneLoaderService.LoadeAcync(Scenes.Empty);
            yield return _sceneLoaderService.LoadeAcync(sceneName);

            SceneBootstrap sceneBootstrap = Object.FindObjectOfType<SceneBootstrap>();

            if (sceneBootstrap == null) 
                throw new NullReferenceException(nameof(sceneBootstrap)+ " not found");
            yield return sceneBootstrap.Initialize(_container);

            _loadingScreen.Hide();

            sceneBootstrap.Run();
        }
    }
}