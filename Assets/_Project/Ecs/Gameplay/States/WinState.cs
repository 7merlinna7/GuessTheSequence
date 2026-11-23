using Assets._Project.Develop.Runtime.Configs.Meta.Wallet;
using Assets._Project.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Project.Develop.Runtime.Meta.Features.PlayerStatistics;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.UI.Gameplay;
using Assets._Project.Develop.Runtime.Utilites.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagement.DataProviders;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.States
{
    public class WinState : EndGameState, IUpdatableState
    {
        private readonly PlayerDataProvider _playerDataProvider;
        private readonly ICoroutinesPerformer _coroutinesPerformer;
        private readonly PlayerStatisticsService _playerStatisticsService;
        private readonly WalletService _wallet;

        private WalletSettingsConfig _walletSettingsConfig;

        private readonly GameplayPopupService _gameplayPopupService;

        public WinState(
            PlayerDataProvider playerDataProvider,
            ICoroutinesPerformer coroutinesPerformer,
            PlayerStatisticsService playerStatisticsService,
            WalletService wallet,
            WalletSettingsConfig walletSettingsConfig,
            GameplayPopupService gameplayPopupService)
        {
            _playerDataProvider = playerDataProvider;
            _coroutinesPerformer = coroutinesPerformer;
            _playerStatisticsService = playerStatisticsService;
            _wallet = wallet;
            _walletSettingsConfig = walletSettingsConfig;
            _gameplayPopupService = gameplayPopupService;
        }

        public override void Enter()
        {
            base.Enter();

            _playerStatisticsService.AddWin();
            _wallet.Add(CurrencyTypes.Gold, _walletSettingsConfig.WalletBalanceWinUpdate);

            _coroutinesPerformer.StartPerform(_playerDataProvider.SaveAcync());

            _gameplayPopupService.OpenWinPopup();
        }

        public void Update(float deltaTime)
        {
        }
    }
}