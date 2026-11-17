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

        private ReactiveVariable<float> _explotionDamage;
        private ReactiveVariable<float> _explotionRadius;

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

            _explotionDamage = entity.ExplotionDamage;
            _explotionRadius = entity.ExplotionRadius;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_isExplode.Value)
            {
                CreateExpotion();
                _isExplode.Value = false;
            }
        }

        private void CreateExpotion()
        {
            _entitiesFactory.CreateExplotion(_transform.position,_team.Value,_explotionRadius.Value,_explotionDamage.Value);
        }
    }
}