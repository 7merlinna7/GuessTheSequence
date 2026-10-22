using Assets._Project.Develop.Runtime.Utilities;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.Sensors
{
    public class BodyCollider : IEntityComponent
    {
        public CapsuleCollider Value;
    }

    public class ContactsDetectingMask : IEntityComponent
    {
        public LayerMask Value;
    }

    public class ContactCollidersBuffer : IEntityComponent
    {
        public Buffer<Collider> Value;
    }

    public class ContactEntitiesBuffer : IEntityComponent
    {
        public Buffer<Entity> Value;
    }
}