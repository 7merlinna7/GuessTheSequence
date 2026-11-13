using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using Assets._Project.Ecs.Gameplay.Features.StagesFeature;

namespace Assets._Project.Ecs.Gameplay.States
{
    public class StageProcessState : State, IUpdatableState
    {
        private readonly StageProviderService _stageProviderService;

        public StageProcessState(StageProviderService stageProviderService)
        {
            _stageProviderService = stageProviderService;
        }

        public override void Enter()
        {
            base.Enter();

            _stageProviderService.SwitchToNext();
            _stageProviderService.StartCurrent();
        }

        public void Update(float deltaTime)
        {
            _stageProviderService.UpdateCurrent(deltaTime);
        }
        public override void Exit()
        {
            base.Exit();
            _stageProviderService.CleanUpCurrent();
        }
    }
}