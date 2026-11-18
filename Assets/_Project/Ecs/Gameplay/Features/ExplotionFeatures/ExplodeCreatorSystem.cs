using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Systems;
using Assets._Project.Ecs.Gameplay.Features.TeamsFeature;
using System;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.ExplotionFeatures
{
    public class ExplodeCreatorSystem : IInitializableSystem, IDisposableSystem
    {
        private readonly EntitiesFactory _entitiesFactory;

        private ReactiveVariable<float> _explotionDamage;
        private ReactiveVariable<float> _explotionRadius;
        private ReactiveVariable<Teams> _team;

        private Transform _transform;

        private ReactiveEvent _exploded; 
        private IDisposable _explodeEventDisposable;

        public ExplodeCreatorSystem(EntitiesFactory entitiesFactory)
        {
            _entitiesFactory = entitiesFactory;
        }

        public void OnInit(Entity entity)
        {
            _transform = entity.Transform;
            _team = entity.Team;
            _explotionDamage = entity.ExplotionDamage;
            _explotionRadius = entity.ExplotionRadius;
            _exploded = entity.Exploded;

            _explodeEventDisposable = entity.ExplodeEvent.Subscribe(CreateExpotion);
        }

        public void OnDispose()
        {
            _explodeEventDisposable.Dispose();
        }

        private void CreateExpotion()
        {
            _entitiesFactory.CreateExplotion(_transform.position,_team.Value,_explotionRadius.Value,_explotionDamage.Value);
            _exploded?.Invoke();
        }
    }
}