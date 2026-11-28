using System.Collections.Generic;

namespace Assets._Project.Ecs.Gameplay.Features.StatsFeature
{
    public interface IStatsEffect
    {
        void ApplyTo(Dictionary<StatTypes, float> stats);
    }
}