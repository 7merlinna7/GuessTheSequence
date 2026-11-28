using Assets._Project.Ecs.Gameplay.EntitiesCore;
using System.Collections.Generic;

namespace Assets._Project.Ecs.Gameplay.Features.StatsFeature
{
    public class BaseStats : IEntityComponent
    {
        public Dictionary<StatTypes, float> Value;
    }

    public class ModifiedStats : IEntityComponent
    {
        public Dictionary<StatTypes, float> Value;
    }

    public class StatEffects : IEntityComponent
    {
        public StatsEffectsList Value;
    }
}