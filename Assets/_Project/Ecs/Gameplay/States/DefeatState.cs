using Assets._Project.Develop.Runtime.Meta.Features.PlayerStatistics;
using Assets._Project.Develop.Runtime.UI.Gameplay;
using Assets._Project.Develop.Runtime.Utilites.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagement.DataProviders;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;

namespace Assets._Project.Ecs.Gameplay.States
{
    public class DefeatState : EndGameState, IUpdatableState
    {
        private readonly ICoroutinesPerformer _coroutinesPerformer;
        private readonly PlayerStatisticsService _playerStatisticsService;
        private readonly PlayerDataProvider _playerDataProvider;

        private readonly GameplayPopupService _gameplayPopupService;

        public DefeatState(
            ICoroutinesPerformer coroutinesPerformer,
            PlayerDataProvider playerDataProvider,
            PlayerStatisticsService playerStatisticsService,
            GameplayPopupService gameplayPopupService)
        {
            _coroutinesPerformer = coroutinesPerformer;
            _playerDataProvider = playerDataProvider;
            _playerStatisticsService = playerStatisticsService;
            _gameplayPopupService = gameplayPopupService;
        }

        public override void Enter()
        {
            base.Enter();
            _playerStatisticsService.AddDefeat();

            _coroutinesPerformer.StartPerform(_playerDataProvider.SaveAcync());
            _gameplayPopupService.OpenDefeatPopup();
        }

        public void Update(float deltaTime)
        {

        }
    }
}