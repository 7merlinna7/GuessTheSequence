using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Meta.PlayerStatistics
{
    [CreateAssetMenu(menuName = "Configs/Meta/PlayerStatisticsStartConfig", fileName = "PlayerStatisticsStartConfig")]
    public class PlayerStatisticsStartConfig : ScriptableObject
    {
        [field: SerializeField] public int ResetStatisticsPrice { get; private set; }
        [field: SerializeField] public int WinsCount { get; private set; }
        [field: SerializeField] public int DefeatsCount { get; private set; }
    }
}