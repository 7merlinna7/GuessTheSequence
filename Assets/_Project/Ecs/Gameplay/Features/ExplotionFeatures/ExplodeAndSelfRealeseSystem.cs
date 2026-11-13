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
        private readonly EntitiesLifeContext _lifeContext;

        private Entity _source;

        private ReactiveVariable<Teams> _team;
        private Transform _transform;
        private ReactiveVariable<bool> _isExplode;

        public ExplodeAndSelfRealeseSystem(EntitiesFactory entitiesFactory, EntitiesLifeContext lifeContext)
        {
            _entitiesFactory = entitiesFactory;
            _lifeContext = lifeContext;
        }

        public void OnInit(Entity entity)
        {
            _transform = entity.Transform;
            _isExplode = entity.IsExplode;
            _team = entity.Team;
            _source = entity;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_isExplode.Value)
                CreateExpotion();
        }

        private void CreateExpotion()
        {
            _entitiesFactory.CreateExplotion(_transform.position,_team.Value);
            _lifeContext.Release(_source);
        }
    }
}