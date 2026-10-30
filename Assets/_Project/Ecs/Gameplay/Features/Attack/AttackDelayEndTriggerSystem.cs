using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Systems;
using System;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.Attack
{
    public class AttackDelayEndTriggerSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent _attackDealayEndEvent;
        private ReactiveEvent _startAttackEvent;

        private ReactiveVariable<float> _delay;
        private ReactiveVariable<float> _attackProcessCurrentTime;

        private bool _alreadyAttacked;

        private IDisposable _timerDisposable;
        private IDisposable _startAttackDisposable;

        public void OnInit(Entity entity)
        {
            _attackDealayEndEvent = entity.AttackDelayEndEvent;
            _startAttackEvent = entity.StartAttackEvent;

            _delay = entity.AttackDelayTime;
            _attackProcessCurrentTime = entity.AttackProcessCurrentTime;

            _timerDisposable = _attackProcessCurrentTime.Subscribe(OnTimerChanged);
            _startAttackDisposable = _startAttackEvent.Subscribe(OnStartAttack);
        }

        private void OnStartAttack()
        {
            _alreadyAttacked = false;
        }

        private void OnTimerChanged(float arg1, float currentTime)
        {
            if(_alreadyAttacked)
                return;

            if (currentTime >= _delay.Value)
            {
                Debug.Log("Attack delay ended");
                _attackDealayEndEvent.Invoke();
                _alreadyAttacked = true;
            }
        }

        public void OnDispose()
        {
            _timerDisposable.Dispose();
            _startAttackDisposable.Dispose();
        }
    }
}