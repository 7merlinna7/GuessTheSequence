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
        private readonly ProjectPresentersFactory _projectPresentersFactory;

        private readonly List<IPresenter> _childPresenters = new();

        public MainMenueScreenPresenter(
            MainMenueScreenView screen,
            MainMenuePopupService popupService,
            ProjectPresentersFactory projectPresentersFactory)
        {
            _screen = screen;
            _popupService = popupService;
            _projectPresentersFactory = projectPresentersFactory;
        }

        public void Initialize()
        {
            _screen.OpenTestPopupButtonClicked += OnOpenTestPopupButtonClicked;

            CreatePlayerStatistics();
            CreateWallet();

            foreach (IPresenter presenter in _childPresenters )
                presenter.Initialize();
        }

        public void Dispose()
        {
            _screen.OpenTestPopupButtonClicked -= OnOpenTestPopupButtonClicked;

            foreach (IPresenter presenter in _childPresenters)
                presenter.Dispose();

            _childPresenters.Clear();
        }

        private void OnOpenTestPopupButtonClicked()
        {
            _popupService.OpenTestPopup();
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