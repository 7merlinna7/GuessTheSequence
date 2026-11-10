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
        private LevelSelector _levelSelector;


        public MainMenu(
            SceneSwitcherService sceneSwitcherService,
            ICoroutinesPerformer coroutinesPerformer,
            PlayerDataProvider dataProvider,
            LevelSelector levelSelector)
        {
            _sceneSwitcherService = sceneSwitcherService;
            _coroutinesPerformer = coroutinesPerformer;
            _levelSelector = levelSelector;
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
            GameplayInputArgs inputArgs = _levelSelector.SelectRandomLevel();
            yield return sceneSwitcherService.ProcessSwitchTo(scene,inputArgs);
        }
    }
}