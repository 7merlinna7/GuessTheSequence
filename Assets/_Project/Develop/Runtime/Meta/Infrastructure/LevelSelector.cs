using Assets._Project.Develop.Runtime.Gameplay.Infrastructure;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Meta.Infrastructure
{
    public class LevelSelector 
    {
        private int _levelsCount;

        public LevelSelector(int levelsCount)
        {
            _levelsCount = levelsCount;
        }

        public GameplayInputArgs SelectRandomLevel()
        {
            int levelNumber = Random.Range(1, _levelsCount);

            GameplayInputArgs inputArgs = new GameplayInputArgs(levelNumber);
            return inputArgs;
        }
    }
}