using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Systems;
using Assets._Project.Ecs.Gameplay.Features.TeamsFeature;
using System.Collections;
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

        public BombExplodeSystem(EntitiesFactory entitiesFactory)
        {
            _entitiesFactory = entitiesFactory;
        }

        public void OnInit(Entity entity)
        {
            _damage = entity.ExplotionDamage;
            _radius = entity.ExplotionRadius;
            _team = entity.Team;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_isExplode.Value)
                Explode();
        }

        private void Explode()
        {
            _entitiesFactory.CreateExplotion(Vector3.zero, _team.Value, _radius.Value, _damage.Value);
        }
    }
}