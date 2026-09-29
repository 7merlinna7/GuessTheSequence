using Assets._Project.Develop.Runtime.Gameplay.GamemodeFeature;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilites.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilites.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.LoadingScreen;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameCycle 
    {
        private Gamemode _gamemode;
        private DIContainer _container;
        ICoroutinesPerformer _coroutinesPerformer;

        public GameCycle(DIContainer container, Gamemode gamemode)
        {
            _container = container;
            _gamemode = gamemode;

            _coroutinesPerformer = _container.Resolve<ICoroutinesPerformer>();
        }

        public void Start()
        {
            _gamemode.Win += Win;
            _gamemode.Defeat += Defeat;

            _gamemode.Start();
        }

        public void Stop()
        {
            _gamemode.Win -= Win;
            _gamemode.Defeat -= Defeat;
        }

        public void Update()
        { 
            _gamemode.Update();
        }

        private void Defeat()
        {
            Debug.Log("Defeat");
            _coroutinesPerformer.StartPerform(ContinueToPlayAgain());
        }

        private void Win()
        {
            Debug.Log("Win");
            _coroutinesPerformer.StartPerform(ContinueToMainMenu());
        }

        private IEnumerator ContinueToMainMenu ()
        {
            Debug.Log("Press SPACE to exit in main menu");
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            Debug.Log("main menue");
            yield return SwitchToMainMenue();
        }

        private IEnumerator ContinueToPlayAgain()
        {
            Debug.Log("Press SPACE to play again");
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            _gamemode.Start();
        }

        public IEnumerator SwitchToMainMenue()
        {
            SceneSwitcherService sceneSwitcherService = _container.Resolve<SceneSwitcherService>();
            ILoadingScreen loadingScreen = _container.Resolve<ILoadingScreen>();

            loadingScreen.Show();
            yield return new WaitForSeconds(1);
            loadingScreen.Hide();
            yield return sceneSwitcherService.ProcessSwitchTo(Scenes.MainMenue);
        }
    }
}