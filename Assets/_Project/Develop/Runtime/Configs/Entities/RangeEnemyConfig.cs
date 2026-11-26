using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Entities
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Entities/RangeEnemyConfig", fileName = "RangeEnemyConfig")]
    public class RangeEnemyConfig : EntityConfig
    {
        [field: SerializeField] public string PrefabPath { get; private set; } = "Entities/Enemies/RangeEnemy";
        [field: SerializeField, Min(0)] public float MoveSpeed { get; private set; } = 10;
        [field: SerializeField, Min(0)] public float RotationSpeed { get; private set; } = 900;
        [field: SerializeField, Min(0)] public float MaxHealth { get; private set; } = 100;
        [field: SerializeField, Min(0)] public float DeathProcessTime { get; private set; } = 0;
        [field: SerializeField, Min(0)] public float SpawnProcessTime { get; private set; } = 2;
        [field: SerializeField, Min(0)] public float InstantAttackDamage { get; private set; } = 10;
        [field: SerializeField, Min(0)] public float AttackRange { get; private set; } = 2;
        [field: SerializeField, Min(0)] public float AttackDelayTime { get; private set; } = 1;
        [field: SerializeField, Min(0)] public float AttackProcessInitialTime { get; private set; } = 2;
        [field: SerializeField, Min(0)] public float AttackCooldownInitialTime { get; private set; } = 1;

    }
}