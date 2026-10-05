using Assets._Project.Develop.Runtime.Gameplay.GamemodeFeature;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Utilites.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameCycle 
    {
        private Gamemode _gamemode;
        private WalletService _wallet;
        private ICoroutinesPerformer _coroutinesPerformer;
        private SceneSwitcherService _sceneSwitcherService;

        private int _winWalletUpdateBalance;
        private int _defeatWalletUpdateBalance;


        public GameCycle(
            ICoroutinesPerformer coroutinesPerformer,
            SceneSwitcherService sceneSwitcherService,
            Gamemode gamemode,
            WalletService walletService
            ,int WinWalletUpdateBalance, int DefeatWalletUpdateBalance)
        {
            _gamemode = gamemode;
            _wallet = walletService;
            _coroutinesPerformer = coroutinesPerformer;
            _sceneSwitcherService = sceneSwitcherService;

            _defeatWalletUpdateBalance = DefeatWalletUpdateBalance;
            _winWalletUpdateBalance = WinWalletUpdateBalance;
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
            _wallet.Spend(CurrencyTypes.Gold,_defeatWalletUpdateBalance);
            Debug.Log("Gold " + _wallet.GetCurrency(CurrencyTypes.Gold).Value);
            _coroutinesPerformer.StartPerform(ContinueToPlayAgain());
        }

        private void Win()
        {
            Debug.Log("Win");
            _wallet.Add(CurrencyTypes.Gold,_winWalletUpdateBalance);
            Debug.Log("Gold "+ _wallet.GetCurrency(CurrencyTypes.Gold).Value);
            _coroutinesPerformer.StartPerform(ContinueToMainMenu());
        }

        private IEnumerator ContinueToMainMenu ()
        {
            Debug.Log("Press SPACE to exit in main menu");
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
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
            yield return _sceneSwitcherService.ProcessSwitchTo(Scenes.MainMenue);
        }
    }
}