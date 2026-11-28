using Assets._Project.Develop.Runtime.Configs.Gameplay.Abilities;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.StatsFeature;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.AbilitiesFeature.Abilities
{
    public class StatChangeAbility : Ability
    {
        private Entity _entity;
        private StatChangeAbilityConfig _config;

        public StatChangeAbility(Entity entity, StatChangeAbilityConfig config) : base(config.ID)
        {
            _entity = entity;
            _config = config;
        }

        public override void Activate()
        {
            _entity.StatEffects.Add(new StatsEffect(_config.statType, _config.GetApplyEffect()));
        }
    }
}