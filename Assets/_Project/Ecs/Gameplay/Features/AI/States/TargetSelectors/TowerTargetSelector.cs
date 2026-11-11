using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.AplyDamage;
using Assets._Project.Ecs.Gameplay.Features.TowerFeature;
using Assets._Project.Ecs.Utilities.Conditions;
using System.Collections.Generic;
using System.Linq;

namespace Assets._Project.Ecs.Gameplay.Features.AI.States.TargetSelectors
{
    public class TowerTargetSelector : ITargetSelector
    {
        public TowerTargetSelector(Entity entity)
        {
        }

        public Entity SelectTargetFrom(IEnumerable<Entity> targets)
        {
            IEnumerable<Entity> selectedTargets = targets.Where(target =>
            {
                bool result = target.HasComponent<IsTower>() && target.HasComponent<TakeDamageRequest>();

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