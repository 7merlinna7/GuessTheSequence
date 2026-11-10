using Assets._Project.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Project.Develop.Runtime.Utilites.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagement.DataProviders;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using System.Collections;

namespace Assets._Project.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenu 
    {
        private SceneSwitcherService _sceneSwitcherService;
        private ICoroutinesPerformer _coroutinesPerformer;
        private PlayerDataProvider _dataProvider;

        public MainMenu(
            SceneSwitcherService sceneSwitcherService,
            ICoroutinesPerformer coroutinesPerformer,
            PlayerDataProvider dataProvider)
        {
            _sceneSwitcherService = sceneSwitcherService;
            _coroutinesPerformer = coroutinesPerformer;
            _dataProvider = dataProvider;
        }

        public void Start()
        {
            
        }
        
        public void SelectLevel()
        {
            _coroutinesPerformer.StartPerform(SwitchToScene(Scenes.Gameplay, _sceneSwitcherService));
        }

        private IEnumerator SwitchToScene(string scene,SceneSwitcherService sceneSwitcherService)
        {
            yield return sceneSwitcherService.ProcessSwitchTo(scene);
        }
    }
}