using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Systems;
using System;

namespace Assets._Project.Ecs.Gameplay.Features.ExplotionFeatures
{
    public class OnExplodeDeathSystem : IInitializableSystem,IDisposableSystem
    {
        private IDisposable _explodedEventDisposable;

        private ReactiveVariable<bool> _isDead;

        public void OnInit(Entity entity)
        {
            _isDead = entity.IsDead;
            _explodedEventDisposable = entity.Exploded.Subscribe(OnExploded);
        }

        public void OnDispose()
        {
            _explodedEventDisposable.Dispose();
        }

        private void OnExploded()
        {
            _isDead.Value = true;
        }
    }
}