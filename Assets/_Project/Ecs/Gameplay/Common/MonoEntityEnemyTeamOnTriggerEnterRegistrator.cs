using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Mono;
using Assets._Project.Ecs.Gameplay.Features.TeamsFeature;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Common
{
    public class MonoEntityEnemyTeamOnTriggerEnterRegistrator : MonoEntityRegistrator
    {
        private Entity _linkedEntity;
        [SerializeField] SphereCollider _collider;

        public override void Register(Entity entity)
        {
            _linkedEntity = entity;
            _collider.radius = entity.ExplotionRadius.Value;
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.GetComponent<MonoEntity>()!= null)
            {
                MonoEntity monoEntity = other.GetComponent<MonoEntity>();

                Entity entity = monoEntity.LinkedEntity;

                ReactiveVariable<Teams> team;

                if (entity.TryGetTeam(out team))
                    if (team.Value != _linkedEntity.Team.Value)
                        _linkedEntity.TriggerEvent?.Invoke();
            }
        }
    }
}