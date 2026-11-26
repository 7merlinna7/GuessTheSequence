using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore;

namespace Assets._Project.Ecs.Gameplay.Features.AI.States
{
    public class AttackRepeatState : State, IUpdatableState
    {
        private ReactiveEvent _attackRequest;
        private ReactiveVariable<bool> _inAttackProcess;
        private ReactiveVariable<bool> _inAttackCooldown;

        public AttackRepeatState(Entity entity)
        {
            _attackRequest = entity.StartAttackRequest;
            _inAttackProcess = entity.InAttackProcess;
            _inAttackCooldown = entity.InAttackCooldown;
        }

        public override void Enter()
        {
            base.Enter();

            _attackRequest.Invoke();
        }

        public void Update(float deltaTime)
        {
            if(_inAttackProcess.Value == false && _inAttackCooldown.Value == false)
                _attackRequest.Invoke();
        }
    }
}