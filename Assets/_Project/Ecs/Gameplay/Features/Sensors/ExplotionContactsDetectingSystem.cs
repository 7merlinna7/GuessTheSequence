using Assets._Project.Develop.Runtime.Utilities;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Systems;
using UnityEngine;
namespace Assets._Project.Ecs.Gameplay.Features.Sensors
{
    public class ExplotionContactsDetectingSystem : IInitializableSystem, IUpdatableSystem
    {
        private Buffer<Collider> _contacts;
        private LayerMask _mask;

        private ReactiveVariable<float> _radius;
        private Transform _transform;
        private ReactiveEvent _explodeRequest;

        public void OnInit(Entity entity)
        {
            _contacts = entity.ContactCollidersBuffer;
            _mask = entity.ContactsDetectingMask;

            _transform = entity.Transform;
            _radius = entity.ExplotionRadius;
            _explodeRequest = entity.ExplodeRequest;
        }

        public void OnUpdate(float deltaTime)
        {
            CastSphere();
            _explodeRequest.Invoke();
        }

        private void CastSphere()
        {
            _contacts.Count = Physics.OverlapSphereNonAlloc(
                    _transform.position,
                    _radius.Value,
                    _contacts.Items,
                    _mask,
                    QueryTriggerInteraction.Ignore);
        }
    }
}