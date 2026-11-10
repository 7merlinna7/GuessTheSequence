using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.AplyDamage;
using Assets._Project.Ecs.Utilities.Conditions;
using System.Collections.Generic;
using System.Linq;

namespace Assets._Project.Ecs.Gameplay.Features.AI.States.TargetSelectors
{
    public class ConditionTargetSelector : ITargetSelector
    {
        private Entity _source;
        private ICompositeCondition _condition;

        public ConditionTargetSelector(Entity entity,ICompositeCondition conditionToSelect)
        {
            _source = entity;
            _condition = conditionToSelect;
        }

        public Entity SelectTargetFrom(IEnumerable<Entity> targets)
        {
            IEnumerable<Entity> selectedTargets = targets.Where(target =>
            {
                bool result = _condition.Evaluate() && target.HasComponent<TakeDamageRequest>();

                if (target.TryGetCanApplayDamage(out ICompositeCondition canApplayDamage))
                {
                    result = result && canApplayDamage.Evaluate();
                }

                return result;
            });

            if (selectedTargets.Any() == false)
                return null;

            Entity currentTarget = selectedTargets.First();

            return currentTarget;
        }

    }
}