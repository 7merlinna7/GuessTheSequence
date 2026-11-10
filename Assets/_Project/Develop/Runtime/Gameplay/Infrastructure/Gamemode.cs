
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class Gamemode
    {
        public event Action Win;
        public event Action Defeat;
        public event Action<string> SequenceCreated;

        private int _sequenceCount;

        public bool IsRunning { get; private set; }

        public Gamemode()
        {

        }


        public void Start()
        {


            //IsRunning = true;
        }

        public void Update()
        {
            if (IsRunning == false)
                return;

            Win.Invoke();
            Defeat.Invoke();
            SequenceCreated.Invoke("");
        }
    }
}