using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.Gameplay.HealthDisplay;
using Assets._Project.Develop.Runtime.UI.Gameplay.ResultPopups;
using Assets._Project.Develop.Runtime.UI.Gameplay.Stages;
using Assets._Project.Develop.Runtime.Utilites.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.StagesFeature;

namespace Assets._Project.Develop.Runtime.UI.Gameplay
{
    public class GameplayPresentersFactory
    {
        private readonly DIContainer _container;

        public GameplayPresentersFactory(DIContainer container)
        {
            _container = container;
        }

        public EntitiesHealthDisplayPresenter CreateEntitiesHealthDisplayPresenter(EntitiesHealthDisplay view)
        {
            return new EntitiesHealthDisplayPresenter(
                _container.Resolve<EntitiesLifeContext>(),
                view,
                this,
                _container.Resolve<ViewsFactory>());
        }

        public EntityHealthPresenter CreateEntityHealthPresenter(Entity entity,BarWithText view)
        {
            return new EntityHealthPresenter(view, entity);
        }

        public StagePresenter CreateStagePresenter(IconTextView view)
        {
            return new StagePresenter(view,_container.Resolve<StageProviderService>());
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
            return new GameplayScreenPresenter(view,this);
        }
    }
}