using Assets._Project.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilites.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilites.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.LoadingScreen;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets._Project.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenu 
    {
        private SceneSwitcherService sceneSwitcherService;//?????

        public void Start(DIContainer container)
        {
            container.Resolve<ICoroutinesPerformer>().StartPerform(WaitForPlayerInput(container));
        }

        private IEnumerator WaitForPlayerInput(DIContainer container)
        {
            Debug.Log("Для выбора режиа нажмите 1 - Цифры, 2 - Символы");
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2));

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("Режим цифры");
                yield return SwitchToScene(container,Scenes.Gameplay);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Debug.Log("Режим буквы");
            }
        }

        private IEnumerator SwitchToScene(DIContainer container, string scene)
        {
            SceneSwitcherService sceneSwitcherService = container.Resolve<SceneSwitcherService>();
            ILoadingScreen loadingScreen = container.Resolve<ILoadingScreen>();

            loadingScreen.Show();

            yield return container.Resolve<ConfigsProviderService>().LoadAsync();

            GameplayInputArgs gameplayInputArgs = new GameplayInputArgs(1);
            yield return new WaitForSeconds(1f);

            loadingScreen.Hide();

            yield return sceneSwitcherService.ProcessSwitchTo(scene, gameplayInputArgs);
        }
    }
}