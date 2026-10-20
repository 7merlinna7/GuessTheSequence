using Assets._Project.Ecs.Gameplay.EntitiesCore;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay
{
    public class TestGameplay 
    {
        private EntitiesFactory _entitiesFactory;
        private Entity _entity;
        private bool _isRunning;

        public TestGameplay(EntitiesFactory entitiesFactory)
        { 
            _entitiesFactory = entitiesFactory;
        }

        public void Start(SequenceType sequenceType)
        {
            if (sequenceType == SequenceType.Numbers)
                _entity = _entitiesFactory.CreateRigidbodyEntity(Vector3.zero);

            if (sequenceType == SequenceType.Letters)
                _entity = _entitiesFactory.CreateCharacterControllerEntity(Vector3.zero);

            _isRunning = true;
        }

        public void Update()
        {
            if (_isRunning == false)
                return;

            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"),0, Input.GetAxisRaw("Vertical"));

            _entity.MoveDirection.Value = input;
            _entity.RotationDirection.Value = input;
        }

    }
}