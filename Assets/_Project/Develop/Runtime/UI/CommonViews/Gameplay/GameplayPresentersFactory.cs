using Assets._Project.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.UI.CommonViews.SequenceFeature;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.MainMenue;

namespace Assets._Project.Develop.Runtime.UI.CommonViews.Gameplay
{
    public class GameplayPresentersFactory
    {
        private readonly DIContainer _container;

        public GameplayPresentersFactory(DIContainer container)
        {
            _container = container;
        }

        public GameplayScreenPresenter CreateGameplayScreenPresenter(SequenceView view)
            => new GameplayScreenPresenter(view, _container.Resolve<GameCycle>(),_container.Resolve<MainMenuePopupService>());
    }
}