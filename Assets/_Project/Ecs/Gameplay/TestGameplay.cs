using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.MovementFeatures;
using System.Collections;
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

        public void Start()
        {
            _entity = _entitiesFactory.CreateTestEntity(Vector3.zero);

            _isRunning = true;
        }

        public void Update()
        {
            if (_isRunning == false)
                return;

            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"),0, Input.GetAxisRaw("Vertical"));

            _entity.GetComponent<MoveDirection>().Value.Value = input;
        }

    }
}