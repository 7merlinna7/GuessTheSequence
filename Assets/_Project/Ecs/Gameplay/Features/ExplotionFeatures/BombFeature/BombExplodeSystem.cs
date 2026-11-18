using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Systems;
using Assets._Project.Ecs.Gameplay.Features.TeamsFeature;
using System;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.ExplotionFeatures.BombFeature
{
    public class BombExplodeSystem : IInitializableSystem, IDisposableSystem
    {
        private readonly EntitiesFactory _entitiesFactory;

        private ReactiveEvent _exploded;
        IDisposable _explodeEventDisposable;

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
            _exploded = entity.Exploded;
            _transform = entity.Transform;

            _explodeEventDisposable = entity.ExplodeEvent.Subscribe(OnExplode);
        }


        public void OnDispose()
        {
            _explodeEventDisposable.Dispose();
        }

        private void OnExplode()
        {
            _entitiesFactory.CreateExplotion(_transform.position, _team.Value, _radius.Value, _damage.Value);
            _exploded?.Invoke();
        }
    }
}