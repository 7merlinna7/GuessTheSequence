using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Systems;
using System.Collections.Generic;

namespace Assets._Project.Ecs.Gameplay.Features.StatsFeature
{
    public class StatsEffectsApplierSystem : IInitializableSystem, IDisposableSystem
    {
        private StatsEffectsList _statsEffects;
        private Dictionary<StatTypes, float> _baseStats;
        private Dictionary<StatTypes, float> _modifiedStats;

        public void OnInit(Entity entity)
        {
            _statsEffects = entity.StatEffects;
            _baseStats = entity.BaseStats;
            _modifiedStats = entity.ModifiedStats;

            _statsEffects.Added += OnStatEffectAdded;
            _statsEffects.Removed += OnStatEffectRemoved;

            RecalculateStats();
        }

        public void OnDispose()
        {
            _statsEffects.Added -= OnStatEffectAdded;
            _statsEffects.Removed -= OnStatEffectRemoved;
        }

        private void RecalculateStats()
        {
            foreach (StatTypes stat in _baseStats.Keys)
                _modifiedStats[stat] = _baseStats[stat];

            foreach (IStatsEffect statsEffect in _statsEffects.Elements)
                statsEffect.ApplyTo(_modifiedStats);
        }

        private void OnStatEffectRemoved(IStatsEffect effect) => RecalculateStats();

        private void OnStatEffectAdded(IStatsEffect effect) => RecalculateStats();

    }
}