using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Systems;
using System;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.Attack
{
    public class AttackCooldownTymerSystem : IInitializableSystem, IUpdatableSystem, IDisposableSystem
    {
        private ReactiveVariable<float> _currentTime;
        private ReactiveVariable<float> _initialTime;
        private ReactiveVariable<bool> _inAttackCooldown;

        private ReactiveEvent _endAttackEvent;

        private IDisposable _endAttackEventDisposable;

        public void OnInit(Entity entity)
        {
            _currentTime = entity.AttackCooldownCurrentTime;
            _initialTime = entity.AttackCooldownInitialTime;
            _inAttackCooldown = entity.InAttackCooldown;

            _endAttackEvent = entity.EndAttackEvent;
            _endAttackEventDisposable = _endAttackEvent.Subscribe(OnEndAttack);
        }

        private void OnEndAttack()
        {
            Debug.Log("CooldownStarted");
            _currentTime.Value = _initialTime.Value;
            _inAttackCooldown.Value = true;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_inAttackCooldown.Value == false)
                return;

            _currentTime.Value -= deltaTime;

            if (CooldownIsOver())
            {
                _inAttackCooldown.Value = false;
                Debug.Log("Cooldown Ended");
            }
        }

        private bool CooldownIsOver() => _currentTime.Value <= 0;

        public void OnDispose()
        {
            _endAttackEventDisposable.Dispose();
        }
    }
}