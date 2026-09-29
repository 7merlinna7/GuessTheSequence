using Assets._Project.Develop.Runtime.Utilities.Configs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.SequenceFeature
{
    public class SequenceFactory 
    {
        private ISequenceConfig _sequenceConfig;

        public SequenceFactory(ISequenceConfig sequenceConfig)
        {
            _sequenceConfig = sequenceConfig;
        }

        public Sequence Create() =>  new Sequence(_sequenceConfig._sequencePool,_sequenceConfig.SequenceLenth);
    }
}