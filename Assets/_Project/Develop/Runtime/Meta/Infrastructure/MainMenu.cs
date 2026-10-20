using Assets._Project.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Project.Develop.Runtime.Utilites.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagement.DataProviders;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using System.Collections;
using UnityEngine;

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
            //_coroutinesPerformer.StartPerform(WaitForPlayerInput(_sceneSwitcherService));
        }

        //private IEnumerator WaitForPlayerInput(SceneSwitcherService sceneSwitcherService)
        //{
        //    Debug.Log("Cохранение - S");

        //    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.S));
        //        Debug.Log("Save");
        //        _coroutinesPerformer.StartPerform(_dataProvider.Save());
        //        yield return null;
        //        Start();
        //}
        
        public void SelectLevel(SequenceType sequenceType)
        {
            _coroutinesPerformer.StartPerform(SwitchToScene(Scenes.Gameplay, sequenceType, _sceneSwitcherService));
        }

        private IEnumerator SwitchToScene(string scene, SequenceType sequenceType,SceneSwitcherService sceneSwitcherService)
        {
            GameplayInputArgs gameplayInputArgs = new GameplayInputArgs(sequenceType);
            yield return sceneSwitcherService.ProcessSwitchTo(scene, gameplayInputArgs);
        }
    }
}