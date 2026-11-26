using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Systems;
using Assets._Project.Ecs.Gameplay.Features.TeamsFeature;
using System;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.Attack.RangeAttack.Shoot
{
    public class InstantShootSystem : IInitializableSystem, IDisposableSystem
    {
        private readonly EntitiesFactory _entitiesFactory;

        private ReactiveEvent _attackDelayEndEvent;

        private Teams _team; 
        private ReactiveVariable<float> _damage;
        private Transform _shootPoint;

        private IDisposable _attackEventEndDisposable;

        public InstantShootSystem(EntitiesFactory entitiesFactory)
        {
            _entitiesFactory = entitiesFactory;
        }

        public void OnInit(Entity entity)
        {
            _attackDelayEndEvent = entity.AttackDelayEndEvent;

            _damage = entity.InstantAttackDamage;
            _shootPoint = entity.ShootPoint;
            _team = entity.Team.Value;

            _attackEventEndDisposable = _attackDelayEndEvent.Subscribe(OnAttackDelayEnd);
        }

        private void OnAttackDelayEnd()
        {
            _entitiesFactory.CreateProjectile(_shootPoint.position, _shootPoint.forward, _damage.Value,_team);
        }

        public void OnDispose()
        {
            _attackEventEndDisposable.Dispose();
        }
    }
}