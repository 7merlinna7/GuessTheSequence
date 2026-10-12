using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Meta.Features;
using Assets._Project.Develop.Runtime.Meta.Features.PlayerStatistics;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.UI;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.MainMenue;
using Assets._Project.Develop.Runtime.Utilites.AssetsManagment;
using Assets._Project.Develop.Runtime.Utilites.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagement.DataProviders;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenueContextRegistrations 
    {
        public static void Process(DIContainer container)
        {
            container.RegisterAsSingle(CreateMainMenu);
            container.RegisterAsSingle(CreatePurchaseResetStatisticChecker);
            container.RegisterAsSingle(CreateMainMenueUIRoot).NonLazy();
            container.RegisterAsSingle(CreateMainMenuePresentersFactory);
            container.RegisterAsSingle(CreateMainMenueScreenPresenter).NonLazy();
            container.RegisterAsSingle(CreateMainMenuePopupService);
        }

        private static MainMenuePopupService CreateMainMenuePopupService(DIContainer c)
        {
            return new MainMenuePopupService(
                c.Resolve<ViewsFactory>(),
                c.Resolve<ProjectPresentersFactory>(),
                c.Resolve<MainMenueUIRoot>());
        }

        private static PurchaseResetStatisticChecker CreatePurchaseResetStatisticChecker(DIContainer c)
            => new PurchaseResetStatisticChecker(
                c.Resolve<ICoroutinesPerformer>(),
                c.Resolve<WalletService>(),
                c.Resolve<PlayerStatisticsService>());

        private static MainMenu CreateMainMenu(DIContainer c)
            => new MainMenu(
                c.Resolve<SceneSwitcherService>(),
                c.Resolve<ICoroutinesPerformer>(),
                c.Resolve<PlayerDataProvider>(),
                c.Resolve<WalletService>(),
                c.Resolve<PlayerStatisticsService>());

        private static MainMenueUIRoot CreateMainMenueUIRoot(DIContainer c)
        {
            ResourcesAssetsLoader assetsLoader = c.Resolve<ResourcesAssetsLoader>();
            MainMenueUIRoot MainMenueUIRootPrefab = assetsLoader.Load<MainMenueUIRoot>("UI/MainMenue/MainMenueUIRoot");

            return Object.Instantiate(MainMenueUIRootPrefab);
        }

        private static MainMenuePresentersFactory CreateMainMenuePresentersFactory(DIContainer c)
        {
            return new MainMenuePresentersFactory(c);
        }

        private static MainMenueScreenPresenter CreateMainMenueScreenPresenter(DIContainer c)
        {
            MainMenueUIRoot uiRoot = c.Resolve<MainMenueUIRoot>();
            MainMenueScreenView view = c
                .Resolve<ViewsFactory>()
                .Create<MainMenueScreenView>(ViewIDs.MainMenueScreen, uiRoot.HUDLayer);

            MainMenueScreenPresenter presenter = c
                .Resolve<MainMenuePresentersFactory>()
                .CreateMainMenueScreen(view);

            return presenter;
        }
    }
}