using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.TowerFeature;
using System;

namespace Assets._Project.Ecs.Gameplay.Features.AI.States
{
    public class FindTargetState : State, IUpdatableState
    {
        private ReactiveVariable<Entity> _currentTarget;

        public FindTargetState(Entity entity,TowerHolderService towerHolderService)
        {
            _currentTarget = entity.CurrentTarget;
            _currentTarget.Value = towerHolderService.Tower;
        }

        public void Update(float deltaTime)
        {
        }
    }
}