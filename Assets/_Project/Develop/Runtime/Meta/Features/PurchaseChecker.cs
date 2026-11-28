using Assets._Project.Develop.Runtime.Meta.Features.PlayerStatistics;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Meta.Features
{
    public class PurchaseChecker 
    {
        public event Action<string> StatisticsReset;

        private WalletService _wallet;
        private PlayerStatisticsService _playerStatistics;

        private int _resetStatisticsPrice = 200;
        private int _bombPrice = 50;

        public PurchaseChecker(WalletService wallet, PlayerStatisticsService playerStatistics)
        {
            _wallet = wallet;
            _playerStatistics = playerStatistics;
        }

        public bool GetBomb()
        {
            if (_wallet.Enough(CurrencyTypes.Gold, _bombPrice))
            {
                _wallet.Spend(CurrencyTypes.Gold, _bombPrice);
                return true;
            }
            else
            {
                return false;
            }
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