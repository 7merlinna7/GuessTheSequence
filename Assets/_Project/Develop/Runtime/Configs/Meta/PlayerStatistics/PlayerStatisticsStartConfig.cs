using Assets._Project.Develop.Runtime.Meta.Features.PlayerStatistics;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Meta.PlayerStatistics
{
    [CreateAssetMenu(menuName = "Configs/Meta/PlayerStatisticsStartConfig", fileName = "PlayerStatisticsStartConfig")]
    public class PlayerStatisticsStartConfig : ScriptableObject
    {
        [field: SerializeField] public int WinsCount { get; private set; }
        [field: SerializeField] public int DefeatsCount { get; private set; }

        [field: SerializeField] private List<StatisticConfig> _statistics;

        public string GetStatisticNameBy(PlayerStatisticType statisticType)
            =>_statistics.First(statistic => statistic.Type == statisticType).Name;

        [Serializable]
        private class StatisticConfig
        {
            [field: SerializeField] public PlayerStatisticType Type { get; private set; }
            [field: SerializeField] public string Name { get; private set; }
        }
    }
}