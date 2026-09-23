using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilites.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilites.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.LoadingScreen;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Infrastructure.EntryPoint
{
    public class GameEntryPoint : MonoBehaviour
    {

        private void Awake()
        {
            SetupAppSettings();

            DIContainer container = new DIContainer();

            EntryPointRegistrations.Process(container);
            container.Resolve<ICoroutinesPerformer>().StartPerform(Initialize(container));

            Debug.Log("DONE");
        }

        private void SetupAppSettings()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
        }

        private IEnumerator Initialize(DIContainer container)
        {
            ILoadingScreen loadingScreen = container.Resolve<ILoadingScreen>();
            SceneSwitcherService sceneSwitcherService = container.Resolve<SceneSwitcherService>();

            loadingScreen.Show();

            yield return container.Resolve<ConfigsProviderService>().LoadAsync();

            yield return new WaitForSeconds(1f);

            loadingScreen.Hide();

            //MoveToNextScene
            yield return sceneSwitcherService.ProcessSwitchTo(Scenes.MainMenue);
        }
    }
}