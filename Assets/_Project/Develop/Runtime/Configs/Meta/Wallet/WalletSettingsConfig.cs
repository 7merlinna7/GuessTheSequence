using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Meta.Wallet
{
    [CreateAssetMenu(menuName = "Configs/Meta/WalletSettingsConfig", fileName = "WalletSettingsConfig")]
    public class WalletSettingsConfig : ScriptableObject
    {
        [field: SerializeField] public int WalletBalanceWinUpdate { get; private set; }
        [field: SerializeField] public int WalletBalanceDefeatUpdate { get; private set; }
    }
}