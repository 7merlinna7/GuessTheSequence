using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.AI;
using Assets._Project.Ecs.Gameplay.Features.AI.States;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay
{
    public class TestGameplay 
    {
        private EntitiesFactory _entitiesFactory;
        private Entity _entity;
        private Entity _ghost;
        private Entity _ghost2;
        private Entity _teleportingGhost;
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
                _entity.AddCurrentTarget();
                _brainsFactory.CreateMainHeroBrain(_entity);

                _ghost2 = _entitiesFactory.CreateTeleportingGhost(Vector3.zero + Vector3.forward * 6 + Vector3.left * 2);
                _brainsFactory.CreateCommonTeleportingGhostBrain(_ghost2);

                _ghost = _entitiesFactory.CreateTeleportingGhost(Vector3.zero + Vector3.forward * 5);
                _brainsFactory.CreateCommonTeleportingGhostBrain(_ghost);
            }

            if (sequenceType == SequenceType.Letters)
            {
                _entitiesFactory.CreateWalkingGhost(Vector3.zero + Vector3.forward * 6 + Vector3.left * 3, 100f);
                _entitiesFactory.CreateWalkingGhost(Vector3.zero + Vector3.forward * 6 + Vector3.right * 3, 80f);

                _teleportingGhost = _entitiesFactory.CreateTeleportingGhost(Vector3.zero);
                _teleportingGhost.AddCurrentTarget();
                _brainsFactory.CreateSmartTeleportingGhostBrain(_teleportingGhost, new MinHealthTargetSelector(_teleportingGhost));
            }

            _isRunning = true;
        }

        public void Update()
        {
            if (_isRunning == false)
                return;

            if (Input.GetKeyDown(KeyCode.R))
                _entitiesFactory.CreateWalkingGhost(Vector3.zero + Vector3.forward * 8 + Vector3.right * 3, 80f);
        }

    }
}