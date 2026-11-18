using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore;

namespace Assets._Project.Ecs.Gameplay.Features.AI.States
{
    public class ExplodeState : State, IUpdatableState
    {
        private ReactiveEvent _explodeEvent;

        public ExplodeState(Entity entity)
        {
            _explodeEvent = entity.ExplodeEvent;
        }

        public void Update(float deltaTime)
        {
            _explodeEvent?.Invoke();
        }
    }
}