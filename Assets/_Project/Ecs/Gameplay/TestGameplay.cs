using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.AI;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets._Project.Ecs.Gameplay
{
    public class TestGameplay 
    {
        private EntitiesFactory _entitiesFactory;
        private Entity _entity;
        private Entity _ghost;
        private bool _isRunning;

        private BrainsFactory _brainsFactory;

        public void Initialize(DIContainer container)
        {
            _entitiesFactory = container.Resolve<EntitiesFactory>();
            _brainsFactory = container.Resolve<BrainsFactory>();
        }

        public void Start(SequenceType sequenceType)
        {
            if (sequenceType == SequenceType.Numbers)
            {
                _entity = _entitiesFactory.CreateHero(Vector3.zero);
                _ghost = _entitiesFactory.CreateWalkingGhost(Vector3.zero + Vector3.forward * 5);
            }

            if (sequenceType == SequenceType.Letters)
                _entity = _entitiesFactory.CreateCharacterControllerEntity(Vector3.zero);

            _isRunning = true;
        }

        public void Update()
        {
            if (_isRunning == false)
                return;

            if (Input.GetKeyDown(KeyCode.R))
                _entity.StartAttackRequest.Invoke();

            if (Input.GetKeyDown(KeyCode.I))
                _brainsFactory.CreateGhostBrain(_ghost);

            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

            _entity.MoveDirection.Value = input;
            _entity.RotationDirection.Value = input;

            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    _entity.TeleportRequest.Invoke();
            //}
        }

    }
}