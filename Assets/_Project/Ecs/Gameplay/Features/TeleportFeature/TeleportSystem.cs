using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Systems;
using Assets._Project.Ecs.Utilities.Conditions;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets._Project.Ecs.Gameplay.Features.TeleportFeature
{
    public class TeleportSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent _teleportRequest;
        private ReactiveEvent _teleportEvent;

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

            _canTeleport = entity.CanTeleport;
            _requestDisposable = _teleportRequest.Subscribe(OnTeleportRequest);
        }

        public void OnDispose()
        {
            _requestDisposable.Dispose();
        }

        private void OnTeleportRequest()
        {
            if (_canTeleport.Evaluate())
            {
                _transform.position += GetTeleportationPoint();

                _teleportEvent.Invoke();
            }
        }

        private Vector3 GetTeleportationPoint()
        { 
           Vector2 rand = Random.insideUnitCircle* _teleportationRadius.Value;
            return new Vector3(rand.x, 0, rand.y);
        }
    }
}