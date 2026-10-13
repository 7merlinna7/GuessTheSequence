using Assets._Project.Develop.Runtime.Infrastructure.DI;

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
            return new MainMenueScreenPresenter(view,_container.Resolve<MainMenuePopupService>(),_container.Resolve<ProjectPresentersFactory>());
        }
    }
}