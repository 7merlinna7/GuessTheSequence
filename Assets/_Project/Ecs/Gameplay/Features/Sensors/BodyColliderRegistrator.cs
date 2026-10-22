using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Mono;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.Sensors
{
    public class BodyColliderRegistrator : MonoEntityRegistrator
    {
        [SerializeField] private CapsuleCollider _body;
        public override void Register(Entity entity)
        {
            entity.AddBodyCollider(_body);
        }
    }
}