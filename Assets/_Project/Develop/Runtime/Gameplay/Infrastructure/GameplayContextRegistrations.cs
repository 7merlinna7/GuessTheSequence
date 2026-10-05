using Assets._Project.Develop.Runtime.Configs.Gameplay.SequenceConfigs;
using Assets._Project.Develop.Runtime.Configs.Meta.Wallet;
using Assets._Project.Develop.Runtime.Gameplay.GamemodeFeature;
using Assets._Project.Develop.Runtime.Gameplay.SequenceFeature;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Utilites.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilites.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilities.Configs.Gameplay.SequenceConfigs;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;

namespace Assets._Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayContextRegistrations 
    {
        private static GameplayInputArgs _inputArgs;
        public static void Process(DIContainer container, GameplayInputArgs args)
        {
            _inputArgs = args;

            container.RegisterAsSingle(CreateSequenceFactory);
            container.RegisterAsSingle(CreateGamemode);
            container.RegisterAsSingle(CreateGameCycle);
        }

        private static SequenceFactory CreateSequenceFactory(DIContainer c)
        {
            ISequenceConfig config = null;
            switch (_inputArgs.LevelType)
            {
                case SequenceType.Letters:
                    config = c.Resolve<ConfigsProviderService>().GetConfig<LettersSequenceConfig>();
                    break;
                case SequenceType.Numbers:
                    config = c.Resolve<ConfigsProviderService>().GetConfig<NumbersSequenceConfig>();
                    break;
            }

            return new SequenceFactory(config);
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
                config.WalletBalanceWinUpdate,
                config.WalletBalanceDefeatUpdate);
        }
    }
}