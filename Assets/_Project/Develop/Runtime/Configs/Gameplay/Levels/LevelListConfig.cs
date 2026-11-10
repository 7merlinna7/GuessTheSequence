using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Gameplay.Levels
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Levels/NewLevelListConfig", fileName = "LevelListConfig")]
    public class LevelListConfig : ScriptableObject
    {
        [SerializeField] private List<LevelConfig> _levelsList;

        public IReadOnlyList<LevelConfig> LevelsList => _levelsList;

        public LevelConfig GetBy(int index)
        {
            index--;
            if (index > _levelsList.Count-1)
                throw new ArgumentOutOfRangeException("Index out of list range");

            return _levelsList[index];
        }
    }
}