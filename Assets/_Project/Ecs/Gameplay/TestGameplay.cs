using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.AI;
using Assets._Project.Ecs.Gameplay.Features.AI.States;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets._Project.Ecs.Gameplay
{
    public class TestGameplay 
    {
        private EntitiesFactory _entitiesFactory;
        private Entity _entity;
        private Entity _ghost;
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
                //_brainsFactory.CreateMainHeroBrain(_entity, new NearestDamagebleTargetSelector(_entity));

                //_entitiesFactory.CreateTeleportingGhost(Vector3.zero + Vector3.forward * 6 + Vector3.left * 2);

                _ghost = _entitiesFactory.CreateTeleportingGhost(Vector3.zero + Vector3.forward * 5);
                _brainsFactory.CreateCommonTeleportingGhostBrain(_ghost);
            }

            if (sequenceType == SequenceType.Letters)
            {
                _entitiesFactory.CreateWalkingGhost(Vector3.zero + Vector3.forward * 6 + Vector3.left * 2, 100f);
                _entitiesFactory.CreateWalkingGhost(Vector3.zero + Vector3.forward * 6 + Vector3.right * 2, 80f);

                _teleportingGhost = _entitiesFactory.CreateTeleportingGhost(Vector3.zero);
                _teleportingGhost.AddCurrentTarget();
                _brainsFactory.CreateSmartTeleportingGhostBrain(_teleportingGhost, new MinHealthTargetSelector(_entity));
            }

            _isRunning = true;
        }

        public void Update()
        {
            if (_isRunning == false)
                return;

            if (Input.GetKeyDown(KeyCode.R))
                _entity.StartAttackRequest.Invoke();
        }

    }
}