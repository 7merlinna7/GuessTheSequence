using Assets._Project.Develop.Runtime.Utilites.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.States
{
    public class DefeatState : EndGameState, IUpdatableState
    {
        private readonly SceneSwitcherService _sceneSwitcherService;
        private readonly ICoroutinesPerformer _coroutinesPerformer;

        public DefeatState(
            SceneSwitcherService sceneSwitcherService,
            ICoroutinesPerformer coroutinesPerformer)
        {
            _sceneSwitcherService = sceneSwitcherService;
            _coroutinesPerformer = coroutinesPerformer;
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Win");
            //апдейт статистики крч обработка defeat
        }

        public void Update(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Q))
                _coroutinesPerformer.StartPerform(_sceneSwitcherService.ProcessSwitchTo(Scenes.MainMenue));
        }
    }
}