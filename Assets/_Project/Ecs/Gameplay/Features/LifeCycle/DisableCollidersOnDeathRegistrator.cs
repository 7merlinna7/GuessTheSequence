using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Mono;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.LifeCycle
{
    public class DisableCollidersOnDeathRegistrator : MonoEntityRegistrator
    {
        [SerializeField] private List<Collider> _colliders;
        public override void Register(Entity entity)
        {
            entity.AddDisableCollidersOnDeath(_colliders);
        }
    }
}