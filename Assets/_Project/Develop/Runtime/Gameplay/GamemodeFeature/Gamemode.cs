using Assets._Project.Develop.Runtime.Gameplay.SequenceFeature;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.GamemodeFeature
{
    public class Gamemode
    {
        public event Action Win;
        public event Action Defeat;

        private int _sequenceCount;
        private Sequence _sequence;

        public bool IsRunning { get; private set; }

        public Gamemode(Sequence sequence)
        {
            _sequence = sequence;
        }

        public void Start()
        {
            _sequence.Create();
            _sequenceCount = 0;

            IsRunning = true;
            Debug.Log(_sequence.Get());
        }

        public void Update()
        {
            if (IsRunning == false)
                return;

            if (Input.anyKeyDown == true)
            {
                if (Input.GetKeyDown(_sequence.GetNextValueKeyCode()))
                {
                    Debug.Log("Good");
                    _sequenceCount++;
                }
                else
                {
                    IsRunning = false;
                    Defeat?.Invoke();
                }
            }

            if (_sequenceCount == _sequence.SequenceLenth)
            {
                IsRunning = false;
                Win?.Invoke();
            }
        }
    }
}