using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Entities
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Entities/NewGhostConfig", fileName = "GhostConfig")]
    public class GhostConfig : EntityConfig
    {
        [field: SerializeField] public string PrefabPath { get; private set; } = "Entities/Enemies/WalkingGhost";
        [field: SerializeField,Min(0)] public float MoveSpeed { get; private set; } = 10;
        [field: SerializeField,Min(0)] public float RotationSpeed { get; private set; } = 900;
        [field: SerializeField,Min(0)] public float MaxHealth { get; private set; } = 100;
        [field: SerializeField,Min(0)] public float BodyContactDamage { get; private set; } = 20;
        [field: SerializeField,Min(0)] public float DeathProcessTime { get; private set; } = 0;
        [field: SerializeField,Min(0)] public float SpawnProcessTime { get; private set; } = 2;
    }
}