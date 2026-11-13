using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilites.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagement.DataProviders;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using Assets._Project.Ecs.Gameplay.Features.StagesFeature;

namespace Assets._Project.Ecs.Gameplay.States
{
    public class GameplayStatesFactory 
    {
        private readonly DIContainer _container;

        public GameplayStatesFactory(DIContainer container)
        {
            _container = container;
        }



        public PreperationState CreatePreperationState()
        {
            return new PreperationState();
        }

        public StageProcessState CreateStageProcessState()
        {
            return new StageProcessState(_container.Resolve<StageProviderService>());
        }

        public WinState CreateWinState()
        {
            return new WinState(
                _container.Resolve<PlayerDataProvider>(),
                _container.Resolve<SceneSwitcherService>(),
                _container.Resolve<ICoroutinesPerformer>());
        }

        public DefeatState CreateDefeatState()
        {
            return new DefeatState(
                _container.Resolve<SceneSwitcherService>(),
                _container.Resolve<ICoroutinesPerformer>());
        }
    }
}