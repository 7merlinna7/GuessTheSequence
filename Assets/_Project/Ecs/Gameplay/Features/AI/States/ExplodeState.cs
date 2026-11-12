using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore;

namespace Assets._Project.Ecs.Gameplay.Features.AI.States
{
    public class ExplodeState : State, IUpdatableState
    {
        private ReactiveVariable<bool> _isExplode;

        public ExplodeState(Entity entity)
        {
            _isExplode = entity.IsExplode;
        }

        public void Update(float deltaTime)
        {
           _isExplode.Value = true;
        }
    }
}