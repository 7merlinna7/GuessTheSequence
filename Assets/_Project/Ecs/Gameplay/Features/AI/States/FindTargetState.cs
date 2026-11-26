using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.AI.States.TargetSelectors;

namespace Assets._Project.Ecs.Gameplay.Features.AI.States
{
    public class FindTargetState : State, IUpdatableState
    {
        private readonly EntitiesLifeContext _lifeContext;
        private ReactiveVariable<Entity> _currentTarget;
        private ITargetSelector _targetSelector;

        public FindTargetState(Entity entity,ITargetSelector targetSelector,EntitiesLifeContext entitiesLifeContext)
        {
            _currentTarget = entity.CurrentTarget;
            _targetSelector = targetSelector;
            _lifeContext = entitiesLifeContext;
        }

        public void Update(float deltaTime)
        {
            _currentTarget.Value = _targetSelector.SelectTargetFrom(_lifeContext.Entities);
        }
    }
}