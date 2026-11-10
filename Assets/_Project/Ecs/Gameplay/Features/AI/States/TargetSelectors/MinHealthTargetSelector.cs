using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.AplyDamage;
using Assets._Project.Ecs.Utilities.Conditions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.AI.States.TargetSelectors
{
    public class MinHealthTargetSelector : ITargetSelector
    {
        private Entity _source;

        public MinHealthTargetSelector(Entity entity)
        {
            _source = entity;
        }

        public Entity SelectTargetFrom(IEnumerable<Entity> targets)
        {
            IEnumerable<Entity> selectedTargets = targets.Where(target =>
            {
                bool result = target.HasComponent<TakeDamageRequest>();

                if (target.TryGetCanApplayDamage(out ICompositeCondition canApplayDamage))
                {
                    result = result && canApplayDamage.Evaluate();
                }

                result = result && target != _source;

                return result;
            });

            if (selectedTargets.Any() == false)
                return null;

            Entity targetWithMinHealth = selectedTargets.First();
            float minHealth = GetTargetHealth(targetWithMinHealth);

            foreach (Entity target in selectedTargets)
            {
                float distance = GetTargetHealth(target);

                if (distance < minHealth)
                {
                    minHealth = distance;
                    targetWithMinHealth = target;
                }
            }

            return targetWithMinHealth;
        }

        private float GetTargetHealth(Entity entity)
           => entity.CurrentHealth.Value;
    }
}