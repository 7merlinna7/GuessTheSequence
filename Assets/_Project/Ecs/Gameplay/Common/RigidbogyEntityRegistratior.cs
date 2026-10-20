using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Mono;
using UnityEngine;
using static Assets._Project.Ecs.Gameplay.Common.CommonComponents;

namespace Assets._Project.Ecs.Gameplay.Common
{
    public class RigidbogyEntityRegistratior : MonoEntityRegistrator
    {
        public override void Register(Entity entity)
        {
            entity.AddComponent(new RigidbodyComponent() { Value = GetComponent<Rigidbody>() });
        }
    }
}