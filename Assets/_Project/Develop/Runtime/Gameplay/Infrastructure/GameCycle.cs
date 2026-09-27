using Assets._Project.Develop.Runtime.Gameplay.GamemodeFeature;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameCycle : MonoBehaviour
    {
        private Gamemode _gamemode;

        public void Start()
        {
            _gamemode = new Gamemode();
            _gamemode.Win += Win;
            _gamemode.Defeat += Defeat;

            _gamemode.Start();
        }

        public void Stop()
        {
            _gamemode.Win -= Win;
            _gamemode.Defeat -= Defeat;
        }

        public void Update()
        { 
            _gamemode.Update();
        }

        private void Defeat()
        {
            Debug.Log("Defeat");
            StartCoroutine(ContinueToPlayAgain());
        }

        private void Win()
        {
            Debug.Log("Win");
            StartCoroutine(ContinueToMainMenu());
        }

        private IEnumerator ContinueToMainMenu ()
        {
            Debug.Log("Press SPACE to exit in main menu");
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            Debug.Log("main menue");
            // main menue
        }

        private IEnumerator ContinueToPlayAgain()
        {
            Debug.Log("Press SPACE to play again");
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            _gamemode.Start();
        }
    }
}