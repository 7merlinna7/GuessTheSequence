using Assets._Project.Develop.Runtime.Configs.Meta.PlayerStatistics;
using Assets._Project.Develop.Runtime.Configs.Meta.Wallet;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Meta.Features.PlayerStatistics;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.CommonViews.PlayerStatistics;
using Assets._Project.Develop.Runtime.UI.CommonViews.Wallet;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.Core.ConfirmPopup;
using Assets._Project.Develop.Runtime.Utilites.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilites.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.Reactive;

namespace Assets._Project.Develop.Runtime.UI
{
    public class ProjectPresentersFactory 
    {
        private readonly DIContainer _container;

        public ProjectPresentersFactory(DIContainer container)
        {
            _container = container;
        }

        public PlayerStatisticsPresenter CreatePlayerStatisticsPresenter(TextTextListView view)
        {
            return new PlayerStatisticsPresenter(
                _container.Resolve<PlayerStatisticsService>(),
                this,
                _container.Resolve<ViewsFactory>(),
                view);
        }

        public StatisticPresenter CreateStatisticsPresenter(
            int value,
            PlayerStatisticType playerStatisticType,
            TextTextView view)
        {
            return new StatisticPresenter(
                value,
                _container.Resolve<ConfigsProviderService>().GetConfig<PlayerStatisticsStartConfig>(),
                playerStatisticType,
                view);
        }

        public CurrencyPresenter CreateCurrencyPresenter(
            IconTextView view,
            IReadonlyVariable<int> currency,
            CurrencyTypes currencyType)
        {
            return new CurrencyPresenter(
                currency,
                currencyType,
                _container.Resolve<ConfigsProviderService>().GetConfig<CurrencyIconsConfig>(),
                view);
        }

        public WalletPresenter CreateWalletPresenter(IconTextView walletView)
        {
            return new WalletPresenter(this,walletView,_container.Resolve<WalletService>());
        }

        public ConfirmPopupPresenter CreateConfirmPopupPresenter(ConfirmPopupView view)
            => new ConfirmPopupPresenter(
                view,
                _container.Resolve<ICoroutinesPerformer>());
    }
}