using Assets._Project.Develop.Runtime.Utilities.Configs;

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