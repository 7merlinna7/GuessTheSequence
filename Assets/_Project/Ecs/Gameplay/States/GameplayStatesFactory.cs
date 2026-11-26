using Assets._Project.Develop.Runtime.Configs.Meta.Wallet;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Meta.Features;
using Assets._Project.Develop.Runtime.Meta.Features.PlayerStatistics;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.UI.Gameplay;
using Assets._Project.Develop.Runtime.Utilites.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilites.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagement.DataProviders;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.AI;
using Assets._Project.Ecs.Gameplay.Features.InputFeature;
using Assets._Project.Ecs.Gameplay.Features.InputFeature.RaycastFeature;
using Assets._Project.Ecs.Gameplay.Features.StagesFeature;
using Assets._Project.Ecs.Gameplay.Features.TowerFeature;
using Assets._Project.Ecs.Gameplay.States.Player;
using Assets._Project.Ecs.Utilities.Conditions;
using UnityEngine;

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
                _container.Resolve<ICoroutinesPerformer>(),
                _container.Resolve<PlayerStatisticsService>(),
                _container.Resolve<WalletService>(),
                _container.Resolve<ConfigsProviderService>().GetConfig<WalletSettingsConfig>(),
                _container.Resolve<GameplayPopupService>());
        }

        public DefeatState CreateDefeatState()
        {
            return new DefeatState(
                _container.Resolve<ICoroutinesPerformer>(),
                _container.Resolve<PlayerDataProvider>(),
                _container.Resolve<PlayerStatisticsService>(),
                _container.Resolve<GameplayPopupService>());
        }

        public GameplayStateMachine CreateCoreLoopState()
        {
            StageProviderService stageProviderService = _container.Resolve<StageProviderService>();

            PreperationState preperationState = new PreperationState();

            StageProcessState stageProcessState = new StageProcessState(_container.Resolve<StageProviderService>());

            FuncCondition preperationToProcessStateCondition =
                new FuncCondition(() => Input.GetKeyDown(KeyCode.Space));

            FuncCondition stageProcessToPreperationStateCondition =
                new FuncCondition(() => stageProviderService.CurrentStageResult.Value == StageResult.Completed);

            GameplayStateMachine coreLoopState = new GameplayStateMachine();

            coreLoopState.AddState(stageProcessState);
            coreLoopState.AddState(preperationState);

            coreLoopState.AddTransition(stageProcessState, preperationState, stageProcessToPreperationStateCondition);
            coreLoopState.AddTransition(preperationState, stageProcessState, preperationToProcessStateCondition);

            return coreLoopState;
        }

        public GameplayStateMachine CreatePlayerStateMachine()
        {
            StageProviderService stageProviderService = _container.Resolve<StageProviderService>();
            PlayerGameplayRayShooter rayShooter = _container.Resolve<PlayerGameplayRayShooter>();
            PlayerInput playerInput = _container.Resolve<PlayerInput>();
            PurchaseChecker purchaseChecker = _container.Resolve<PurchaseChecker>();
            EntitiesFactory entitiesFactory = _container.Resolve<EntitiesFactory>();

            PlayerAttackState playerAttackState = new PlayerAttackState(entitiesFactory, rayShooter, playerInput);
            PlayerPreperationState playerPreperationState = new PlayerPreperationState(entitiesFactory, rayShooter, playerInput,purchaseChecker);

            FuncCondition preperationToProcessStateCondition = new FuncCondition(() => Input.GetKeyDown(KeyCode.Space));

            FuncCondition stageProcessToPreperationStateCondition =
                new FuncCondition(() => stageProviderService.CurrentStageResult.Value == StageResult.Completed);

            GameplayStateMachine playerStateMachine = new GameplayStateMachine();
            playerStateMachine.AddState(playerAttackState);
            playerStateMachine.AddState(playerPreperationState);

            playerStateMachine.AddTransition(playerAttackState,playerPreperationState,stageProcessToPreperationStateCondition);
            playerStateMachine.AddTransition(playerPreperationState, playerAttackState, preperationToProcessStateCondition);

            return playerStateMachine;
        }

        public GameplayStateMachine CreateGameplayStateMachine()
        {
            StageProviderService stageProviderService = _container.Resolve<StageProviderService>();
            TowerHolderService towerHolderService = _container.Resolve<TowerHolderService>();

            GameplayStateMachine coreLoopState = CreateCoreLoopState();
            GameplayStateMachine playerGameplayState = CreatePlayerStateMachine();

            GameplayParallelState gameplayLoopState = new GameplayParallelState(coreLoopState, playerGameplayState);

            DefeatState defeatState = CreateDefeatState();
            WinState winState = CreateWinState();

            ICompositeCondition gameplayLoopToWinStateCondition = new CompositeCondition()
                .Add(new FuncCondition(() => stageProviderService.CurrentStageResult.Value == StageResult.Completed))
                .Add(new FuncCondition(() => stageProviderService.HasNextStage() == false));

            ICompositeCondition gameplayLoopToDefeatStateCondition = new CompositeCondition()
                .Add(new FuncCondition(() =>
                {
                    if (towerHolderService.Tower != null)
                        return towerHolderService.Tower.IsDead.Value;

                    return false;
                }));

            GameplayStateMachine gameplayCycle = new GameplayStateMachine();
            gameplayCycle.AddState(gameplayLoopState);
            gameplayCycle.AddState(winState);
            gameplayCycle.AddState(defeatState);

            gameplayCycle.AddTransition(gameplayLoopState, defeatState, gameplayLoopToDefeatStateCondition);
            gameplayCycle.AddTransition(gameplayLoopState, winState, gameplayLoopToWinStateCondition);

            return gameplayCycle;
        }
    }
}