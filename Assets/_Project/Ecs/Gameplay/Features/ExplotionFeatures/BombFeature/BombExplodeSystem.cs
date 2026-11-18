using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Systems;
using Assets._Project.Ecs.Gameplay.Features.TeamsFeature;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.ExplotionFeatures.BombFeature
{
    public class BombExplodeSystem : IInitializableSystem, IUpdatableSystem
    {
        private readonly EntitiesFactory _entitiesFactory;

        private ReactiveVariable<bool> _isExplode;
        private ReactiveVariable<float> _damage;
        private ReactiveVariable<float> _radius;
        private ReactiveVariable<Teams> _team;
        private Transform _transform;

        public BombExplodeSystem(EntitiesFactory entitiesFactory)
        {
            _entitiesFactory = entitiesFactory;
        }

        public void OnInit(Entity entity)
        {
            _damage = entity.ExplotionDamage;
            _radius = entity.ExplotionRadius;
            _team = entity.Team;
            _isExplode = entity.IsExplode;
            _transform = entity.Transform;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_isExplode.Value)
            {
                Explode();
                _isExplode.Value = false;
            }
        }

        private void Explode()
        {
            _entitiesFactory.CreateExplotion(_transform.position, _team.Value, _radius.Value, _damage.Value);
        }
    }
}