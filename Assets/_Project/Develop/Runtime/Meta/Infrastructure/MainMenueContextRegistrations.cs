using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Meta.Features;
using Assets._Project.Develop.Runtime.Meta.Features.PlayerStatistics;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Utilites.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagement;
using Assets._Project.Develop.Runtime.Utilities.DataManagement.DataProviders;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;

namespace Assets._Project.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenueContextRegistrations 
    {
        public static void Process(DIContainer container)
        {
            container.RegisterAsSingle(CreateMainMenu);
            container.RegisterAsSingle(CreatePurchaseResetStatisticChecker);
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
    }
}