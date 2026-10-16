using Assets._Project.Develop.Runtime.Meta.Features;
using Assets._Project.Develop.Runtime.UI.CommonViews.LevelSelection;
using Assets._Project.Develop.Runtime.UI.CommonViews.PlayerStatistics;
using Assets._Project.Develop.Runtime.UI.CommonViews.Wallet;
using Assets._Project.Develop.Runtime.UI.Core;
using System;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.UI.MainMenue
{
    public class MainMenueScreenPresenter : IPresenter
    {
        MainMenueScreenView _screen;
        private readonly MainMenuePopupService _popupService;
        private readonly PurchaseResetStatisticChecker _resetStatisticChecker;

        private readonly ProjectPresentersFactory _projectPresentersFactory;
        private readonly MainMenuePresentersFactory _mainMenuePresentersFactory;

        private readonly List<IPresenter> _childPresenters = new();

        public MainMenueScreenPresenter(
            MainMenueScreenView screen,
            MainMenuePopupService popupService,
            ProjectPresentersFactory projectPresentersFactory,
            MainMenuePresentersFactory mainMenuePresentersFactory,
            PurchaseResetStatisticChecker resetStatisticChecker)
        {
            _resetStatisticChecker = resetStatisticChecker;
            _screen = screen;
            _popupService = popupService;
            _projectPresentersFactory = projectPresentersFactory;
            _mainMenuePresentersFactory = mainMenuePresentersFactory;
        }

        public void Initialize()
        {
            _screen.ResetStatisticsButtonClicked += OnResetStatisticsButtonClicked;
            _resetStatisticChecker.StatisticsReset += OpenConfirmPopup;

            CreatePlayerStatistics();
            CreateWallet();
            CreateLevelSelector();

            foreach (IPresenter presenter in _childPresenters )
                presenter.Initialize();
        }

        public void Dispose()
        {
            _screen.ResetStatisticsButtonClicked -= OnResetStatisticsButtonClicked;
            _resetStatisticChecker.StatisticsReset -= OpenConfirmPopup;

            foreach (IPresenter presenter in _childPresenters)
                presenter.Dispose();

            _childPresenters.Clear();
        }

        private void OpenConfirmPopup(string text)
        {
            _popupService.OpenConfirmPopup().SetPopupText(text);
        }

        private void OnResetStatisticsButtonClicked()
        {
            _resetStatisticChecker.Reset();
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

        private void CreateLevelSelector()
        {
            LevelSelectionPresenter levelSelectionPresenter = _mainMenuePresentersFactory.CreateLevelSelectionPresenter(_screen.LevelSelectionView);
            _childPresenters.Add(levelSelectionPresenter);
        }
    }
}