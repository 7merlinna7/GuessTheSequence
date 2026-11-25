using Assets._Project.Develop.Runtime.Meta.Features;
using Assets._Project.Develop.Runtime.Meta.Infrastructure;
using Assets._Project.Develop.Runtime.UI.CommonViews.PlayerStatistics;
using Assets._Project.Develop.Runtime.UI.CommonViews.Wallet;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.Utilites.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagement.DataProviders;
using System;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.UI.MainMenue
{
    public class MainMenueScreenPresenter : IPresenter
    {
        MainMenueScreenView _screen;
        private readonly MainMenuePopupService _popupService;

        private readonly PurchaseChecker _resetStatisticChecker;
        private readonly MainMenu _mainMenue;

        private readonly ProjectPresentersFactory _projectPresentersFactory;

        private readonly PlayerDataProvider _playerDataProvider;
        private readonly ICoroutinesPerformer _coroutinesPerformer;


        private readonly List<IPresenter> _childPresenters = new();

        public MainMenueScreenPresenter(
            MainMenueScreenView screen,
            MainMenuePopupService popupService,
            ProjectPresentersFactory projectPresentersFactory,
            MainMenu mainMenu,
            PurchaseChecker resetStatisticChecker,
            PlayerDataProvider playerDataProvider,
            ICoroutinesPerformer coroutinesPerformer)
        {
            _resetStatisticChecker = resetStatisticChecker;
            _screen = screen;
            _popupService = popupService;
            _projectPresentersFactory = projectPresentersFactory;
            _mainMenue = mainMenu;
            _playerDataProvider = playerDataProvider;
            _coroutinesPerformer = coroutinesPerformer;
        }

        public void Initialize()
        {
            _screen.ResetStatisticsButtonClicked += OnResetStatisticsButtonClicked;
            _screen.PlayButtonClicked += OnPlayButtonClicked;

            _resetStatisticChecker.StatisticsReset += OpenConfirmPopup;

            CreatePlayerStatistics();
            CreateWallet();

            foreach (IPresenter presenter in _childPresenters )
                presenter.Initialize();
        }

        public void Dispose()
        {
            _screen.ResetStatisticsButtonClicked -= OnResetStatisticsButtonClicked;
            _screen.PlayButtonClicked -= OnPlayButtonClicked;

            _resetStatisticChecker.StatisticsReset -= OpenConfirmPopup;

            foreach (IPresenter presenter in _childPresenters)
                presenter.Dispose();

            _childPresenters.Clear();
        }

        private void OpenConfirmPopup(string text)
        {
            _popupService.OpenConfirmPopup().SetPopupText(text);
        }

        private void OnPlayButtonClicked()
        {
            _mainMenue.SelectLevel();
        }

        private void OnResetStatisticsButtonClicked()
        {
            _resetStatisticChecker.Reset();
            _coroutinesPerformer.StartPerform(_playerDataProvider.SaveAcync());

        }

        private void CreatePlayerStatistics()
        {
            PlayerStatisticsPresenter statisticsPresenter = _projectPresentersFactory.CreatePlayerStatisticsPresenter(_screen.StatisticView);
            _childPresenters.Add(statisticsPresenter);
        }

        private void CreateWallet()
        {
            WalletPresenter walletPresenter = _projectPresentersFactory.CreateWalletPresenter(_screen.WalletView);
            _childPresenters.Add(walletPresenter);
        }

    }
}