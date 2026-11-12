using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Systems;
using Assets._Project.Ecs.Gameplay.Features.TeamsFeature;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.ExplotionFeatures
{
    public class ExplodeAndSelfRealeseSystem : IInitializableSystem, IUpdatableSystem
    {
        private readonly EntitiesFactory _entitiesFactory;

        private ReactiveVariable<Teams> _team;
        private Transform _transform;
        private ReactiveVariable<bool> _isDead;
        private ReactiveVariable<bool> _isExplode;

        public ExplodeAndSelfRealeseSystem(EntitiesFactory entitiesFactory, Entity entity)
        {
            _entitiesFactory = entitiesFactory;

            _team = entity.Team;
            _transform = entity.Transform;
            _isDead = entity.IsDead;
            _isExplode = entity.IsExplode;
        }

        public void OnInit(Entity entity)
        {
            _transform = entity.Transform;
            _isDead = entity.IsDead;
            _isExplode = entity.IsExplode;
            _team = entity.Team;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_isExplode.Value)
                CreateExpotion();
        }

        private void CreateExpotion()
        {
            _entitiesFactory.CreateExplotion(_transform.position,_team.Value);
            _isDead.Value = true;
        }
    }
}