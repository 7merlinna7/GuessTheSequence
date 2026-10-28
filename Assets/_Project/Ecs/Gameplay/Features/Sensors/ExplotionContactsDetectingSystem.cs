using Assets._Project.Develop.Runtime.Utilities;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Systems;
using System;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.Sensors
{
    public class ExplotionContactsDetectingSystem : IInitializableSystem, IDisposableSystem
    {
        private Buffer<Collider> _contacts;
        private LayerMask _mask;

        private ReactiveEvent _teleportEvent;
        private IDisposable _eventDisposable;

        private CapsuleCollider _body;

        private ReactiveVariable<float> _radius;
        private Transform _transform;

        public void OnInit(Entity entity)
        {
            _contacts = entity.ContactCollidersBuffer;
            _mask = entity.ContactsDetectingMask;

            _body = entity.BodyCollider;
            _transform = entity.Transform;
            _radius = entity.ExplotionRadius;

            _teleportEvent = entity.TeleportEvent;

            _eventDisposable = _teleportEvent.Subscribe(OnTeleportEvent);
        }

        public void OnDispose()
        {
            _eventDisposable.Dispose();
        }

        private void OnTeleportEvent()
        {
            CastSphere();

            RemoveSelfFromContacts();
        }


        private void RemoveSelfFromContacts()
        {
            int indexToRemove = -1;

            for (int i = 0; i < _contacts.Count; i++)
            {
                if (_contacts.Items[i] == _body)
                {
                    indexToRemove = i;
                    break;
                }
            }

            if (indexToRemove >= 0)
            {
                for (int i = indexToRemove; i < _contacts.Count - 1; i++)
                {
                    _contacts.Items[i] = _contacts.Items[i + 1];
                }
                _contacts.Count--;
            }
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