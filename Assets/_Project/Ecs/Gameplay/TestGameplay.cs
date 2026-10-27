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
            {
                _entity = _entitiesFactory.CreateTeleportingGhost(Vector3.zero);
                _entitiesFactory.CreateWalkingGhost(Vector3.zero + Vector3.forward * 5);
            }

            if (sequenceType == SequenceType.Letters)
                _entity = _entitiesFactory.CreateCharacterControllerEntity(Vector3.zero);

            _isRunning = true;
        }

        public void Update()
        {
            if (_isRunning == false)
                return;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _entity.TeleportRequest.Invoke();
            }
        }

    }
}