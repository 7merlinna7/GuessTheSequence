using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Entities
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Player/NewPlayerConfig", fileName = "PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [field: SerializeField, Min(0)] public float ExplotionDamage { get; private set; } = 50;
        [field: SerializeField, Min(0)] public float ExplotionRadius{ get; private set; } = 3;
    }
}