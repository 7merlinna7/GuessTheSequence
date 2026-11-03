using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Systems;
using Assets._Project.Ecs.Utilities.Conditions;
using System;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.TeleportFeature
{
    public class TeleportSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent<Vector3> _teleportRequest;
        private ReactiveEvent _teleportEvent;

        private ReactiveVariable<bool> _inTeleportProcess;


        private Transform _transform;
        private ReactiveVariable<float> _teleportationRadius;

        private ICompositeCondition _canTeleport;
        private IDisposable _requestDisposable;

        public void OnInit(Entity entity)
        {
            _teleportRequest = entity.TeleportRequest;
            _teleportEvent = entity.TeleportEvent;

            _transform = entity.Transform;
            _teleportationRadius = entity.TeleprtationRadius;
            _inTeleportProcess = entity.InTeleportProcess;

            _canTeleport = entity.CanTeleport;
            _requestDisposable = _teleportRequest.Subscribe(OnTeleportRequest);
        }

        public void OnDispose()
        {
            _requestDisposable.Dispose();
        }

        private void OnTeleportRequest(Vector3 direction)
        {
            if (_canTeleport.Evaluate())
            {
                _transform.position += direction.normalized * _teleportationRadius.Value;

                _inTeleportProcess.Value = true;
                _teleportEvent.Invoke(); 
            }
        }
    }
}