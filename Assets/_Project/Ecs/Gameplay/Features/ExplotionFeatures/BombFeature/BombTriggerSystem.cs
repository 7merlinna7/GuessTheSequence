using Assets._Project.Develop.Runtime.Utilities;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Systems;
using Assets._Project.Ecs.Gameplay.Features.TeamsFeature;
using System;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.ExplotionFeatures.BombFeature
{
    public class BombTriggerSystem : IInitializableSystem,IUpdatableSystem
    {
        private readonly CollidersRegistryService _collidersRegistryService;

        private Buffer<Collider> _contacts;
        private Buffer<Entity> _contactsEntities;
        private LayerMask _mask;

        private ReactiveVariable<float> _radius;
        private Transform _transform;

        private ReactiveVariable<bool> _isExplode;
        private ReactiveVariable<Teams> _team;

        public BombTriggerSystem(CollidersRegistryService collidersRegistryService)
        {
            _collidersRegistryService = collidersRegistryService;
        }

        public void OnInit(Entity entity)
        {
            _isExplode = entity.IsExplode;

            _contacts = entity.ContactCollidersBuffer;
            _contactsEntities = entity.ContactEntitiesBuffer;
            _mask = entity.ContactsDetectingMask;
            _transform = entity.Transform;
            _radius = entity.ExplotionRadius;
            _team = entity.Team;
        }

        public void OnUpdate(float deltaTime)
        {
            GetEntitiesContactsColliders();
            AddContactsEntities();

            if (CheckContacts())
                _isExplode.Value = true;
        }

        private void GetEntitiesContactsColliders()
        {
            _contacts.Count = Physics.OverlapSphereNonAlloc(
                    _transform.position,
                    _radius.Value,
                    _contacts.Items,
                    _mask,
                    QueryTriggerInteraction.Ignore);
        }

        public void AddContactsEntities()
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
        }

        private bool CheckContacts()
        {
            bool result = false;

            if (_contacts.Count == 0)
                return result;

            for (int i = 0; i < _contacts.Count; i++)
            {
                if (_contactsEntities.Items[i].TryGetTeam(out ReactiveVariable<Teams> entityTeam))
                    if (entityTeam.Value == _team.Value)
                        result = result || false;
                    else
                        result = result || true;
            }

            return result;
        }
    }
}