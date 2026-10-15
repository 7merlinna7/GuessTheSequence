using Assets._Project.Develop.Runtime.Meta.Features.PlayerStatistics;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Meta.Features
{
    public class PurchaseResetStatisticChecker 
    {
        public event Action<string> StatisticsReset;

        private WalletService _wallet;
        private PlayerStatisticsService _playerStatistics;

        private int _resetStatisticsPrice = 200;

        public PurchaseResetStatisticChecker(WalletService wallet, PlayerStatisticsService playerStatistics)
        {
            _wallet = wallet;
            _playerStatistics = playerStatistics;
        }

        public void Reset()
        {
            if (_wallet.Enough(CurrencyTypes.Gold, _resetStatisticsPrice))
            {
                StatisticsReset?.Invoke("Статистика сброшена");
                _playerStatistics.Reset();
                _wallet.Spend(CurrencyTypes.Gold, _resetStatisticsPrice);
            }
            else
            {
                StatisticsReset?.Invoke("Не достаточно золота для сброса статистики");
            }
        }
    }
}