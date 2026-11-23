using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.UI.Gameplay.ResultPopups;
using Assets._Project.Develop.Runtime.Utilites.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;

namespace Assets._Project.Develop.Runtime.UI.Gameplay
{
    public class GameplayPresentersFactory
    {
        private readonly DIContainer _container;

        public GameplayPresentersFactory(DIContainer container)
        {
            _container = container;
        }

        public WinPopupPresenter CreateWinPopupPresenter(WinPopupView winPopupView)
        {
            return new WinPopupPresenter(
                _container.Resolve<ICoroutinesPerformer>(),
                winPopupView,
                _container.Resolve<SceneSwitcherService>());
        }

        public DefeatPopupPresenter CreateDefeatPopupPresenter(DefeatPopupView defeatPopupView)
        {
            return new DefeatPopupPresenter(
                _container.Resolve<ICoroutinesPerformer>(),
                defeatPopupView,
                _container.Resolve<SceneSwitcherService>());
        }

        public GameplayScreenPresenter CreateScreenPresenter(GameplayScreenView view)
        {
            return new GameplayScreenPresenter(view);
        }
    }
}