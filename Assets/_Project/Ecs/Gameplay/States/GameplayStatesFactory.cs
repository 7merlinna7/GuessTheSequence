using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilites.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagement.DataProviders;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using Assets._Project.Ecs.Gameplay.Features.StagesFeature;
using Assets._Project.Ecs.Gameplay.Features.TowerFeature;
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
                _container.Resolve<SceneSwitcherService>(),
                _container.Resolve<ICoroutinesPerformer>());
        }

        public DefeatState CreateDefeatState()
        {
            return new DefeatState(
                _container.Resolve<SceneSwitcherService>(),
                _container.Resolve<ICoroutinesPerformer>());
        }

        public GameplayStateMachine CreateCoreLoopState()
        {
            StageProviderService stageProviderService = _container.Resolve<StageProviderService>();

            PreperationState preperationState = new PreperationState();
            StageProcessState stageProcessState = new StageProcessState(_container.Resolve<StageProviderService>());

            FuncCondition preperationToProcessStateCondition =
                new FuncCondition(()=> Input.GetKeyDown(KeyCode.Space));

            FuncCondition stageProcessToPreperationStateCondition =
                new FuncCondition(() => stageProviderService.CurrentStageResult.Value == StageResult.Completed);

            GameplayStateMachine coreLoopState = new GameplayStateMachine();

            coreLoopState.AddState(preperationState);
            coreLoopState.AddState(stageProcessState);

            coreLoopState.AddTransition(stageProcessState,preperationState,stageProcessToPreperationStateCondition);
            coreLoopState.AddTransition(preperationState, stageProcessState, preperationToProcessStateCondition);

            return coreLoopState;
        }

        public GameplayStateMachine CreateGameplayStateMachine ()
        {
            StageProviderService stageProviderService = _container.Resolve<StageProviderService> ();
            TowerHolderService towerHolderService = _container.Resolve<TowerHolderService>();

            GameplayStateMachine coreLoopState = CreateCoreLoopState();
            DefeatState defeatState = CreateDefeatState();
            WinState winState = CreateWinState();

            ICompositeCondition coreLoopToWinStateCondition = new CompositeCondition()
                .Add(new FuncCondition(() => stageProviderService.CurrentStageResult.Value == StageResult.Completed))
                .Add(new FuncCondition(() => stageProviderService.HasNextStage() == false));

            ICompositeCondition coreLoopStateToDefeatStateCondition = new CompositeCondition()
                .Add(new FuncCondition(() =>
                {
                    if (towerHolderService.Tower != null)
                        return towerHolderService.Tower.IsDead.Value;

                    return false;
                }));

            GameplayStateMachine gameplayCycle = new GameplayStateMachine();
            gameplayCycle.AddState(coreLoopState);
            gameplayCycle.AddState(winState);
            gameplayCycle.AddState(defeatState);

            gameplayCycle.AddTransition(coreLoopState,defeatState,coreLoopStateToDefeatStateCondition);
            gameplayCycle.AddTransition(coreLoopState,winState,coreLoopToWinStateCondition);

            return gameplayCycle;
        }
    }
}