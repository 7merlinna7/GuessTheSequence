using Assets._Project.Develop.Runtime.Meta.Features.PlayerStatistics;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Utilites.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using System;
using System.Collections;

namespace Assets._Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameCycle 
    {
        public event Action<string,Action> GameplayResult;
        public event Action<string> SequenceCreated
        {
            add { _gamemode.SequenceCreated += value;}
            remove { _gamemode.SequenceCreated -= value;}
        }


        private Gamemode _gamemode;
        private WalletService _wallet;
        private ICoroutinesPerformer _coroutinesPerformer;
        private SceneSwitcherService _sceneSwitcherService;

        private int _winWalletUpdateBalance;
        private int _defeatWalletUpdateBalance;
        private PlayerStatisticsService _playerStatistics;


        public GameCycle(
            ICoroutinesPerformer coroutinesPerformer,
            SceneSwitcherService sceneSwitcherService,
            Gamemode gamemode,
            WalletService walletService,
            PlayerStatisticsService playerStatistics
            ,int WinWalletUpdateBalance, int DefeatWalletUpdateBalance)
        {
            _gamemode = gamemode;
            _wallet = walletService;
            _coroutinesPerformer = coroutinesPerformer;
            _sceneSwitcherService = sceneSwitcherService;
            _playerStatistics = playerStatistics;

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
            if (_wallet.Enough(CurrencyTypes.Gold, _defeatWalletUpdateBalance))
                _wallet.Spend(CurrencyTypes.Gold, _defeatWalletUpdateBalance);
            else
                _wallet.SpendAll(CurrencyTypes.Gold);

                _playerStatistics.AddDefeat();

            GameplayResult?.Invoke("Defeat", ContinueToPlayAgain);
        }

        private void Win()
        {
            _wallet.Add(CurrencyTypes.Gold,_winWalletUpdateBalance);
            _playerStatistics.AddWin();
            GameplayResult?.Invoke("Win", ContinueToMainMenu);
        }

        private void ContinueToMainMenu()
        {
            _coroutinesPerformer.StartPerform(SwitchToMainMenue());
        }

        private void ContinueToPlayAgain()
        {
            _gamemode.Start();
        }

        private IEnumerator SwitchToMainMenue()
        {
            yield return _sceneSwitcherService.ProcessSwitchTo(Scenes.MainMenue);
        }
    }
}