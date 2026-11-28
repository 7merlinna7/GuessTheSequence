using Assets._Project.Develop.Runtime.Configs.Gameplay.Abilities;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.AbilitiesFeature.Abilities;
using System;

namespace Assets._Project.Ecs.Gameplay.Features.Player
{
    public class PlayerUpgradesFactory 
    {
        private DIContainer _container;

        public PlayerUpgradesFactory(DIContainer container)
        {
            _container = container;
        }

        public Ability CreateAbilityFor(Entity entity,AbilityConfig config)
        {
            switch (config)
            {
                case StatChangeAbilityConfig changeAbilityConfig:
                    return new StatChangeAbility(entity, changeAbilityConfig);

                default:
                    throw new ArgumentException();
            }
        }
    }
}