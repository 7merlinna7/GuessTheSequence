using Assets._Project.Develop.Runtime.Gameplay.SequenceFeature;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.GamemodeFeature
{
    public class Gamemode
    {
        public event Action Win;
        public event Action Defeat;

        private int _sequenceLenth = 5;
        private int _sequenceCount = 0;
        private Sequence _sequence;

        public bool IsRunning { get; private set; }

        private Dictionary<KeyCode, char> _sequencePool = new Dictionary<KeyCode, char>()
        {
            { KeyCode.Alpha0,'0' },
            { KeyCode.Alpha1,'1' },
            { KeyCode.Alpha2,'2' },
            { KeyCode.Alpha3,'3' },
            { KeyCode.Alpha4,'4' },
            { KeyCode.Alpha5,'5' },
            { KeyCode.Alpha6,'6' },
            { KeyCode.Alpha7,'7' },
            { KeyCode.Alpha8,'8' },
            { KeyCode.Alpha9,'9' },
        };

        public void Start()
        {
            _sequence = new Sequence(_sequencePool, _sequenceLenth);
            _sequence.Create();

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

            if (_sequenceCount == _sequenceLenth)
            {
                IsRunning = false;
                Win?.Invoke();
            }
        }
    }
}