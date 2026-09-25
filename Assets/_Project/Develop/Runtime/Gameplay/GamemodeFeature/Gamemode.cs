using Assets._Project.Develop.Runtime.Gameplay.SequenceService;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.GamemodeFeature
{
    public class Gamemode: MonoBehaviour
    {
        private int _sequenceLenth = 5;
        private int _sequenceCount = 0;
        private Sequence _sequence;
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

            Debug.Log(_sequence.Get());
        }

        public void Update()
        {
            if (Input.anyKeyDown == true)
            {
                if (Input.GetKeyDown(_sequence.GetNextValueKeyCode()))
                {
                    Debug.Log("Good");
                    _sequenceCount++;
                }
                else
                    Debug.Log("Defeat");
            }

            if (_sequenceCount == _sequenceLenth)
                Debug.Log("Win");
        }
    }
}