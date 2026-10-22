using Assets._Project.Develop.Runtime.Configs.Meta.Wallet;
using Assets._Project.Develop.Runtime.Gameplay.SequenceFeature;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Meta.Features.PlayerStatistics;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Utilites.AssetsManagment;
using Assets._Project.Develop.Runtime.Utilites.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilites.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Mono;

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
            container.RegisterAsSingle(CreateCollidersRegistryService);
        }

        private static CollidersRegistryService CreateCollidersRegistryService(DIContainer c)
            => new CollidersRegistryService();

        private static EntitiesFactory CreateEntitiesFactory(DIContainer c)
        {  return new EntitiesFactory(c); }

        private static EntitiesLifeContext CreateEntitiesLifeContext(DIContainer c)
            => new EntitiesLifeContext();

        private static MonoEntitiesFactory CreateMonoEntitiesFactory(DIContainer c)
        {
            return new MonoEntitiesFactory(
                c.Resolve<ResourcesAssetsLoader>(),
                c.Resolve<EntitiesLifeContext>(),
                c.Resolve<CollidersRegistryService>());
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