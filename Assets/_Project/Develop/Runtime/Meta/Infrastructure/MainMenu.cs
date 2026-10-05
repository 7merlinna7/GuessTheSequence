using Assets._Project.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Project.Develop.Runtime.Meta.Features.PlayerStatistics;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Utilites.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagement;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenu 
    {
        private SceneSwitcherService _sceneSwitcherService;
        private ICoroutinesPerformer _coroutinesPerformer;
        private ISaveLoadService _saveLoadService;
        private Coroutine _playerInputCoroutine;
        private PlayerData _playerData;

        public MainMenu(
            SceneSwitcherService sceneSwitcherService,
            ICoroutinesPerformer coroutinesPerformer,
            ISaveLoadService saveLoadService)
        {
            _sceneSwitcherService = sceneSwitcherService;
            _coroutinesPerformer = coroutinesPerformer;
            _saveLoadService = saveLoadService;
            _playerData = new PlayerData();
        }

        public void Start()
        {
            _playerInputCoroutine = _coroutinesPerformer.StartPerform(WaitForPlayerInput(_sceneSwitcherService));
        }

        private IEnumerator WaitForPlayerInput(SceneSwitcherService sceneSwitcherService)
        {
            Debug.Log("Для выбора режиа нажмите 1 - Цифры, 2 - Буквы");
            Debug.Log("Для просмотра статистики нажмите 3, для сохранения - S");

            yield return new WaitUntil(() => Input.anyKeyDown);

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
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Debug.Log($"Побед: {_playerData.WinsCountData},Поражений: {_playerData.DefeatCountData}");
                Debug.Log("Золота в наличии: "+ _playerData.WalletData[CurrencyTypes.Gold]);
            }
            else if(Input.GetKeyDown(KeyCode.S))
            {
                //не сохраняет дату кошелька исправить
                Debug.Log("Save");
                _coroutinesPerformer.StartPerform(_saveLoadService.Save(_playerData));
                Start();
            }
            else
            {
                Start();
                yield break;
            }
        }

        private IEnumerator SwitchToScene(string scene, SequenceType sequenceType,SceneSwitcherService sceneSwitcherService)
        {
            GameplayInputArgs gameplayInputArgs = new GameplayInputArgs(sequenceType);
            yield return sceneSwitcherService.ProcessSwitchTo(scene, gameplayInputArgs);
        }
    }
}