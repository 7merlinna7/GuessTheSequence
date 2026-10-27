using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Systems;
using Assets._Project.Ecs.Utilities.Conditions;
using System;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.TeleportFeature
{
    public class TeleportEnergySystem : IInitializableSystem, IUpdatableSystem, IDisposableSystem
    {
        private ReactiveEvent _teleportEvent;
        private IDisposable _eventDisposable;

        private ReactiveVariable<float> _currentEnergy;
        private ReactiveVariable<float> _energyToTeleport;

        public void OnInit(Entity entity)
        {
            _currentEnergy = entity.CurrentTeleportEnergy;
            _energyToTeleport = entity.EnergyToTeleport;

            _teleportEvent = entity.TeleportEvent;
            _eventDisposable = _teleportEvent.Subscribe(OnTeleportEvent);
        }

        public void OnUpdate(float deltaTime)
        {


            
        }

        public void OnDispose()
        {
            _eventDisposable.Dispose();
        }

        private void OnTeleportEvent()
        {
            _currentEnergy.Value -= _energyToTeleport.Value;
            Debug.Log("CurrentEnergy " + _currentEnergy.Value);
        }
    }
}