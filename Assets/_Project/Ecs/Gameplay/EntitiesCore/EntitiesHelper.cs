using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.Features.TeamsFeature;

namespace Assets._Project.Ecs.Gameplay.EntitiesCore
{
    public class EntitiesHelper 
    {
        public static bool TryTakeDamageFrom(Entity source, Entity damageble, float damage)
        {
            if (damageble.TryGetTakeDamageRequest(out ReactiveEvent<float> damageRequest) == false)
                return false;

            if (source.TryGetTeam(out ReactiveVariable<Teams> sourceTeam)
                && damageble.TryGetTeam(out ReactiveVariable<Teams> damagebleTeam))
            {
                if (sourceTeam.Value == damagebleTeam.Value)
                    return false;
            }

            damageRequest.Invoke(damage);
            return true;
        }

    }
}