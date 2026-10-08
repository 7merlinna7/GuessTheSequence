using Assets._Project.Develop.Runtime.Meta.Features.PlayerStatistics;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Utilites.CoroutinesManagment;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Meta.Features
{
    public class PurchaseResetStatisticChecker 
    {
        private ICoroutinesPerformer _coroutinesPerformer;

        private WalletService _wallet;
        private PlayerStatisticsService _playerStatistics;

        private int _resetStatisticsPrice = 200;

        public PurchaseResetStatisticChecker(ICoroutinesPerformer coroutinesPerformer, WalletService wallet, PlayerStatisticsService playerStatistics)
        {
            _coroutinesPerformer = coroutinesPerformer;
            _wallet = wallet;
            _playerStatistics = playerStatistics;
        }

        public void Start()
        {
            _coroutinesPerformer.StartPerform(WaitForPlayerInput());
        }

        private IEnumerator WaitForPlayerInput() 
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.R));

            Debug.Log("Корутина для сброса статистики запущена");

            if (_wallet.Enough(CurrencyTypes.Gold, _resetStatisticsPrice))
            {
                Debug.Log("Статистика сброшена");
                _playerStatistics.Reset();
                _wallet.Spend(CurrencyTypes.Gold, _resetStatisticsPrice);
            }
            else
            {
                Debug.Log("Не достаточно золота для сброса статистики");
            }

            yield return null;
            Start();
        }
    }
}