using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Meta.Features;
using Assets._Project.Develop.Runtime.Meta.Infrastructure;
using Assets._Project.Develop.Runtime.Utilites.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagement.DataProviders;

namespace Assets._Project.Develop.Runtime.UI.MainMenue
{
    public class MainMenuePresentersFactory 
    {
        private readonly DIContainer _container;

        public MainMenuePresentersFactory(DIContainer container)
        {
            _container = container;
        }

        public MainMenueScreenPresenter CreateMainMenueScreen(MainMenueScreenView view)
        {
            return new MainMenueScreenPresenter(
                view,
                _container.Resolve<MainMenuePopupService>(),
                _container.Resolve<ProjectPresentersFactory>(),
                _container.Resolve<MainMenu>(),
                _container.Resolve<PurchaseChecker>(),
                _container.Resolve<PlayerDataProvider>(),
                _container.Resolve<ICoroutinesPerformer>());
        }
    }
}