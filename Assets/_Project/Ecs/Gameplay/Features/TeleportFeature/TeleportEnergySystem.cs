using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Systems;
using System;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.TeleportFeature
{
    public class TeleportEnergySystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent _teleportEvent;
        private ReactiveEvent _rechargeEnergyTimerIsOver;
        private IDisposable _eventDisposable;
        private IDisposable _rechargeDisposable;

        private ReactiveVariable<float> _currentEnergy;
        private ReactiveVariable<float> _maxEnergy;
        private ReactiveVariable<float> _rechargeCoefficient;
        private ReactiveVariable<float> _energyToTeleport;

        public void OnInit(Entity entity)
        {
            _currentEnergy = entity.CurrentTeleportEnergy;
            _maxEnergy = entity.MaxTeleportEnergy;
            _energyToTeleport = entity.EnergyToTeleport;

            _rechargeCoefficient = entity.TeleportEnergyRechargeCoefficient;

            _teleportEvent = entity.TeleportEvent;
            _eventDisposable = _teleportEvent.Subscribe(OnTeleportEvent);

            _rechargeEnergyTimerIsOver = entity.RechargeEnergyTimerIsOver;
            _rechargeDisposable = _rechargeEnergyTimerIsOver.Subscribe(Recharge);
        }

        public void OnDispose()
        {
            _eventDisposable.Dispose();
            _rechargeDisposable.Dispose();
        }

        private void OnTeleportEvent()
        {
            _currentEnergy.Value -= _energyToTeleport.Value;
        }

        private void Recharge()
        {
            if(_currentEnergy.Value == _maxEnergy.Value)
                return;

            _currentEnergy.Value = MathF.Min(
                _maxEnergy.Value ,
                _currentEnergy.Value + _maxEnergy.Value * _rechargeCoefficient.Value);

            Debug.Log("Energy "+ _currentEnergy.Value);
        }
    }
}