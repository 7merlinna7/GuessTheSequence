using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Utilities.Configs
{
    public interface ISequenceConfig
    {
        public Dictionary<KeyCode, char> _sequencePool { get; }
        public int SequenceLenth { get; }

        public SequenceType SequenceType { get; }
    }
}