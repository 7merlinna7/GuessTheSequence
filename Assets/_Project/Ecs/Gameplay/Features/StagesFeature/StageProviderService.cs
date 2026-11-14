using Assets._Project.Develop.Runtime.Configs.Gameplay.Levels;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;

namespace Assets._Project.Ecs.Gameplay.Features.StagesFeature
{
    public class StageProviderService 
    {
        private ReactiveVariable<int> _currentStageNumber = new();
        private ReactiveVariable<StageResult> _currentStageResult = new();

        private LevelConfig _levelConfig;
        private StagesFactory _stagesFactory;

        private IStage _currentStage;
        private IDisposable _stageEndedDisposable;

        public StageProviderService(
            LevelConfig levelConfig,
            StagesFactory sagesFactory)
        {
            _levelConfig = levelConfig;
            _stagesFactory = sagesFactory;
        }

        public IReadonlyVariable<int> CurrentStageNumber => _currentStageNumber;
        public IReadonlyVariable<StageResult> CurrentStageResult => _currentStageResult;

        public bool HasNextStage() => _currentStageNumber.Value < StagesCount;

        public int StagesCount => _levelConfig.StageConfigs.Count;

        public void SwitchToNext()
        {
            if (HasNextStage() == false)
                throw new InvalidOperationException();

            if (_currentStage != null)
                CleanUpCurrent();

            _currentStageNumber.Value++;
            _currentStageResult.Value = StageResult.Uncompleted;

            _currentStage = _stagesFactory.Create(_levelConfig.StageConfigs[_currentStageNumber.Value - 1]);
        }

        public void StartCurrent()
        {
            _stageEndedDisposable = _currentStage.Completed.Subscribe(OnStageCompleated);
            _currentStage.Start();
        }

        private void OnStageCompleated()
        {
            _currentStageResult.Value = StageResult.Completed;
        }

        public void UpdateCurrent(float deltaTime) => _currentStage.Update(deltaTime);

        public void CleanUpCurrent() => _currentStage.CleanUp();

        public void Dispose() => _currentStage?.Dispose();
    }
}