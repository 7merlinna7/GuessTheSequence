using Assets._Project.Develop.Runtime.Configs.Gameplay.SequenceConfigs;
using Assets._Project.Develop.Runtime.Configs.Meta.Wallet;
using Assets._Project.Develop.Runtime.Gameplay.SequenceFeature;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Meta.Features.PlayerStatistics;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.UI;
using Assets._Project.Develop.Runtime.UI.CommonViews.Gameplay;
using Assets._Project.Develop.Runtime.UI.CommonViews.SequenceFeature;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.MainMenue;
using Assets._Project.Develop.Runtime.Utilites.AssetsManagment;
using Assets._Project.Develop.Runtime.Utilites.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilites.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.Configs.Gameplay.SequenceConfigs;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Mono;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayContextRegistrations 
    {
        private static GameplayInputArgs _inputArgs;
        public static void Process(DIContainer container, GameplayInputArgs args)
        {
            _inputArgs = args;

            container.RegisterAsSingle(CreateGamemode);
            container.RegisterAsSingle(CreateGameCycle);
            container.RegisterAsSingle(CreateEntitiesFactory);
            container.RegisterAsSingle(CreateEntitiesLifeContext);
            container.RegisterAsSingle(CreateMonoEntitiesFactory).NonLazy();
        }

        private static EntitiesFactory CreateEntitiesFactory(DIContainer c)
        {  return new EntitiesFactory(c); }

        private static EntitiesLifeContext CreateEntitiesLifeContext(DIContainer c)
            => new EntitiesLifeContext();

        private static MonoEntitiesFactory CreateMonoEntitiesFactory(DIContainer c)
        {
            return new MonoEntitiesFactory(
                c.Resolve<ResourcesAssetsLoader>(),
                c.Resolve<EntitiesLifeContext>());
        }

        private static Gamemode CreateGamemode(DIContainer c)
            => new Gamemode(c.Resolve<SequenceFactory>().Create());

        private static GameCycle CreateGameCycle(DIContainer c)
        {
            WalletSettingsConfig config = c.Resolve<ConfigsProviderService>().GetConfig<WalletSettingsConfig>();

           return new GameCycle(
                c.Resolve<ICoroutinesPerformer>(),
                c.Resolve<SceneSwitcherService>(),
                c.Resolve<Gamemode>(),
                c.Resolve<WalletService>(),
                c.Resolve<PlayerStatisticsService>(),
                config.WalletBalanceWinUpdate,
                config.WalletBalanceDefeatUpdate);
        }

    }
}