using Assets._Project.Develop.Runtime.Utilities;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Systems;
using System;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.ExplotionFeatures
{
    public class ExplotionContactsEntitiesFilterSystem : IInitializableSystem, IDisposableSystem
    {
        private Buffer<Collider> _contacts;
        private Buffer<Entity> _contactsEntities;

        private ReactiveEvent _teleportEvent;
        private ReactiveEvent _dealExplotionDamageEvent;
        private IDisposable _eventDisposable;

        private readonly CollidersRegistryService _collidersRegistryService;

        public ExplotionContactsEntitiesFilterSystem(CollidersRegistryService collidersRegistryService)
        {
            _collidersRegistryService = collidersRegistryService;
        }

        public void OnInit(Entity entity)
        {
            _contacts = entity.ContactCollidersBuffer;
            _contactsEntities = entity.ContactEntitiesBuffer;

            _teleportEvent = entity.TeleportEvent;
            _dealExplotionDamageEvent = entity.DealExplotionDamageEvent;

            _eventDisposable = _teleportEvent.Subscribe(Filter);
        }

        public void OnDispose()
        {
            _eventDisposable.Dispose();
        }

        public void Filter()
        {
            _contactsEntities.Count = 0;

            for (int i = 0; i < _contacts.Count; i++)
            {
                Collider collider = _contacts.Items[i];

                Entity contactEntity = _collidersRegistryService.GetBy(collider);
                if (contactEntity != null)
                {
                    _contactsEntities.Items[_contactsEntities.Count] = contactEntity;
                    _contactsEntities.Count++;
                }
            }
            _dealExplotionDamageEvent.Invoke();
        }
    }
}