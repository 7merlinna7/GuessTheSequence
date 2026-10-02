using Assets._Project.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Project.Develop.Runtime.Utilites.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenu 
    {
        public void Start(SceneSwitcherService sceneSwitcherService,ICoroutinesPerformer coroutinesPerformer)
        {

            coroutinesPerformer.StartPerform(WaitForPlayerInput(sceneSwitcherService));
        }

        private IEnumerator WaitForPlayerInput(SceneSwitcherService sceneSwitcherService)
        {
            Debug.Log("Для выбора режиа нажмите 1 - Цифры, 2 - Буквы");
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2));

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("Режим цифры");
                yield return SwitchToScene(Scenes.Gameplay,SequenceType.Numbers,sceneSwitcherService);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Debug.Log("Режим буквы");

                yield return SwitchToScene(Scenes.Gameplay, SequenceType.Letters,sceneSwitcherService);
            }
        }

        private IEnumerator SwitchToScene(string scene, SequenceType sequenceType,SceneSwitcherService sceneSwitcherService)
        {
            GameplayInputArgs gameplayInputArgs = new GameplayInputArgs(sequenceType);
            yield return sceneSwitcherService.ProcessSwitchTo(scene, gameplayInputArgs);
        }
    }
}