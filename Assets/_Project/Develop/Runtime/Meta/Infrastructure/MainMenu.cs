using Assets._Project.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Project.Develop.Runtime.Meta.Features.PlayerStatistics;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Utilites.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagement.DataProviders;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenu 
    {
        private SceneSwitcherService _sceneSwitcherService;
        private ICoroutinesPerformer _coroutinesPerformer;
        private PlayerDataProvider _dataProvider;
        private WalletService _wallet;
        private PlayerStatisticsService _playerStatistics;

        public MainMenu(
            SceneSwitcherService sceneSwitcherService,
            ICoroutinesPerformer coroutinesPerformer,
            PlayerDataProvider dataProvider,
            WalletService walletService,
            PlayerStatisticsService playerStatistics)
        {
            _sceneSwitcherService = sceneSwitcherService;
            _coroutinesPerformer = coroutinesPerformer;
            _dataProvider = dataProvider;
            _wallet = walletService;
            _playerStatistics = playerStatistics;
        }

        public void Start()
        {
            _coroutinesPerformer.StartPerform(WaitForPlayerInput(_sceneSwitcherService));
        }

        private IEnumerator WaitForPlayerInput(SceneSwitcherService sceneSwitcherService)
        {
            Debug.Log("Для выбора режиа нажмите 1 - Цифры, 2 - Буквы");
            Debug.Log("Статистика - 3, сохранение- S, сброс - R");

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
                Debug.Log($"Побед: {_playerStatistics.WinsCount},Поражений: {_playerStatistics.DefeatsCount}");
                Debug.Log("Золота в наличии: "+ _wallet.GetCurrency(CurrencyTypes.Gold).Value);
                Start();
            }
            else if(Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("Save");
                _coroutinesPerformer.StartPerform(_dataProvider.Save());
                Start();
            }
            else if(Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log(_playerStatistics.ResetStatisticsPrice);
                if (_wallet.Enough(CurrencyTypes.Gold, _playerStatistics.ResetStatisticsPrice))//Вынести в отдельный метод
                {
                    _playerStatistics.Reset();.//ПОЧЕМУ 0
                    _wallet.Spend(CurrencyTypes.Gold,_playerStatistics.ResetStatisticsPrice);//(В отдельный класс \ сервис)
                    Start();
                }
                else
                {
                    Debug.Log("Не достаточно золота для сброса статистики");
                    Start();
                }
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