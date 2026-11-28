using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.AplyDamage;
using Assets._Project.Ecs.Gameplay.Features.TeamsFeature;
using Assets._Project.Ecs.Gameplay.Features.TowerFeature;
using Assets._Project.Ecs.Utilities.Conditions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.AI.States.TargetSelectors
{
    public class NearestDamagebleTargetSelector : ITargetSelector
    {
        private Entity _source;
        private Transform _sourceTransform;
        ReactiveVariable<Teams> _sourceTeam;

        public NearestDamagebleTargetSelector(Entity entity)
        {
            _source = entity;
            _sourceTransform = entity.Transform;
            _sourceTeam = entity.Team;
        }

        public Entity SelectTargetFrom(IEnumerable<Entity> targets)
        {
            IEnumerable<Entity> selectedTargets = targets.Where(target =>
            {
                ReactiveVariable<Teams> targetTeam;

                target.TryGetTeam(out targetTeam);

                bool result = target.HasComponent<TakeDamageRequest>() && targetTeam.Value != _sourceTeam.Value;

                if (target.TryGetCanApplayDamage(out ICompositeCondition canApplayDamage))
                {
                    result = result && canApplayDamage.Evaluate();
                }

                result = result && target != _source;

                return result;
            });

            if (selectedTargets.Any() == false)
                return null;

            Entity closestTarget = selectedTargets.First();
            float minDistance = GetDistanceToTarget(closestTarget);

            foreach (Entity target in selectedTargets)
            {
                float distance = GetDistanceToTarget(target);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestTarget = target;
                }
            }

            return closestTarget;
        }

        private float GetDistanceToTarget(Entity target) => (_sourceTransform.position - target.Transform.position).magnitude;

    }
}