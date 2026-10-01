using Assets._Project.Develop.Runtime.Configs.Gameplay.SequenceConfigs;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Gameplay.SequenceConfigs
{

    [CreateAssetMenu(menuName = "Configs/Gameplay/LettersSequenceConfig", fileName = "LettersSequenceConfig")]

    public class LettersSequenceConfig : ScriptableObject,ISequenceConfig
    {
        [field: SerializeField]
        public Dictionary<KeyCode, char> _sequencePool { get; private set; } = new Dictionary<KeyCode, char>()
        {
            { KeyCode.Q,'Q' },
            { KeyCode.W,'W' },
            { KeyCode.E,'E' },
            { KeyCode.R,'R' },
            { KeyCode.T,'T' },
            { KeyCode.Y,'Y' },
            { KeyCode.U,'U' },
            { KeyCode.I,'I' },
            { KeyCode.O,'O' },
            { KeyCode.P,'P' },
        };

        [field: SerializeField] public int SequenceLenth { get; private set; }
        [field: SerializeField] public SequenceType SequenceType { get; private set; } = SequenceType.Letters;

    }
}