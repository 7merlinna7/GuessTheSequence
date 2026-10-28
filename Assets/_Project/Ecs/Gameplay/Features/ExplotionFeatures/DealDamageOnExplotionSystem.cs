using Assets._Project.Develop.Runtime.Utilities;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Systems;
using Assets._Project.Ecs.Gameplay.Features.AplyDamage;
using System;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.ExplotionFeatures
{
    public class DealDamageOnExplotionSystem : IInitializableSystem, IDisposableSystem
    {
        private Buffer<Entity> _contacts;
        private ReactiveVariable<float> _damage;

        private ReactiveEvent _dealExplotionDamageEvent;
        private IDisposable _eventDisposable;

        public void OnInit(Entity entity)
        {
            _contacts = entity.ContactEntitiesBuffer;
            _damage = entity.ExplotionDamage;

            _dealExplotionDamageEvent = entity.DealExplotionDamageEvent;
            _eventDisposable = _dealExplotionDamageEvent.Subscribe(DealDamage);
        }

        public void OnDispose()
        {
            _eventDisposable.Dispose();
        }

        private void DealDamage()
        {
            for (int i = 0; i < _contacts.Count; i++)
            {
                Entity contactEntity = _contacts.Items[i];

                    if (contactEntity.HasComponent<TakeDamageRequest>())
                        contactEntity.TakeDamageRequest.Invoke(_damage.Value);
                Debug.Log("DealDamage");
            }
        }
    }
}