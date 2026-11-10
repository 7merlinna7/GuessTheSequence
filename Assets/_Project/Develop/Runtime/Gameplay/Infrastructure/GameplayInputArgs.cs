using Assets._Project.Develop.Runtime.Utilities.SceneManagment;

namespace Assets._Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayInputArgs : IInputSceneArgs
    {
        private int _levelNumber;
        public GameplayInputArgs(int levelNumber)
        {
            _levelNumber = levelNumber;
        }

        public int LevelNumber => _levelNumber;
    }
}