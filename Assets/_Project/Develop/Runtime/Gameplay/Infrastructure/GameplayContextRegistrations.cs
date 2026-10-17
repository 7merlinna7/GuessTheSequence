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
using UnityEngine;

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
            container.RegisterAsSingle(CreateGameplayPresentersFactory);
            container.RegisterAsSingle(CreateGameplayUIRoot).NonLazy();
            container.RegisterAsSingle(CreateGameplayScreenPresenter).NonLazy();
            container.RegisterAsSingle(CreateGameplayPopupServicePopupService);
        }

        private static GameplayPopupService CreateGameplayPopupServicePopupService(DIContainer c)
        {
            return new GameplayPopupService(
                c.Resolve<ViewsFactory>(),
                c.Resolve<ProjectPresentersFactory>(),
                c.Resolve<ScreenUIRoot>());
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
                c.Resolve<PlayerStatisticsService>(),
                config.WalletBalanceWinUpdate,
                config.WalletBalanceDefeatUpdate);
        }

        private static ScreenUIRoot CreateGameplayUIRoot(DIContainer c)
        {
            ResourcesAssetsLoader assetsLoader = c.Resolve<ResourcesAssetsLoader>();
            ScreenUIRoot GameplayUIRootPrefab = assetsLoader.Load<ScreenUIRoot>("UI/UIRoot");

            return Object.Instantiate(GameplayUIRootPrefab);
        }

        private static GameplayPresentersFactory CreateGameplayPresentersFactory (DIContainer c) => new GameplayPresentersFactory(c);

        private static GameplayScreenPresenter CreateGameplayScreenPresenter(DIContainer c)
        {
            ScreenUIRoot uiRoot = c.Resolve<ScreenUIRoot>();
            SequenceView view = c
                .Resolve<ViewsFactory>()
                .Create<SequenceView>(ViewIDs.SequenceView, uiRoot.HUDLayer);

            GameplayScreenPresenter presenter = c
                .Resolve<GameplayPresentersFactory>()
                .CreateGameplayScreenPresenter(view);

            return presenter;
        }
    }
}