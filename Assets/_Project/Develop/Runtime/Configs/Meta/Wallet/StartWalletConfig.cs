using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Meta.Wallet
{
    [CreateAssetMenu(menuName = "Configs/Meta/StartWalletConfig", fileName = "StartWalletConfig")]
    public class StartWalletConfig : ScriptableObject
    {
        [field: SerializeField] public int WalletBalance {  get; private set; }
        [field: SerializeField] public int WinsCount {  get; private set; }
        [field: SerializeField] public int DefeatsCount {  get; private set; }
    }
}