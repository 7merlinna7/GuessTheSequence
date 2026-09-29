using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Utilities.Configs
{

    [CreateAssetMenu(menuName = "Configs/Gameplay/NumbersSequenceConfig", fileName = "NumbersSequenceConfig")]

    public class NumbersSequenceConfig : ScriptableObject,ISequenceConfig
    {
        [field: SerializeField] public Dictionary<KeyCode, char> _sequencePool { get; private set; } = new Dictionary<KeyCode, char>()
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

        [field: SerializeField] public int SequenceLenth { get; private set; }
        [field: SerializeField] public SequenceType SequenceType { get; private set; } = SequenceType.Numbers;

    }
}