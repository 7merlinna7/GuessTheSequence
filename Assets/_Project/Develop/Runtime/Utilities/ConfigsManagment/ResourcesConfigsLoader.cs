using Assets._Project.Develop.Runtime.Configs.Gameplay.SequenceConfigs;
using Assets._Project.Develop.Runtime.Configs.Meta.PlayerStatistics;
using Assets._Project.Develop.Runtime.Configs.Meta.Wallet;
using Assets._Project.Develop.Runtime.Utilites.AssetsManagment;
using Assets._Project.Develop.Runtime.Utilities.Configs.Gameplay.SequenceConfigs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Utilites.ConfigsManagment
{
    public class ResourcesConfigsLoader : IConfigsLoader
    {
        private readonly ResourcesAssetsLoader _resources;
        private readonly Dictionary<Type, string> _configResourcesPath = new()
        {
            { typeof(NumbersSequenceConfig),"Configs/NumbersSequenceConfig" },
            { typeof(LettersSequenceConfig),"Configs/LettersSequenceConfig" },
            { typeof(StartWalletConfig),"Configs/StartWalletConfig"},
            { typeof(WalletSettingsConfig),"Configs/WalletSettingsConfig"},
            { typeof(PlayerStatisticsStartConfig),"Configs/PlayerStatisticsStartConfig"},
            { typeof(CurrencyIconsConfig),"Configs/CurrencyIconsConfig"}
        };

        public ResourcesConfigsLoader(ResourcesAssetsLoader resources)
        {
            _resources = resources;
        }

        public IEnumerator LoadAsync(Action<Dictionary<Type, object>> onConfigsLoaded)
        {
            Dictionary<Type, object> loadedConfigs = new();
            foreach (KeyValuePair<Type, string> configResourcesPath in _configResourcesPath)
            {
                ScriptableObject config = _resources.Load<ScriptableObject>(configResourcesPath.Value);
                loadedConfigs.Add(configResourcesPath.Key, config);
                yield return null;
            }

            onConfigsLoaded?.Invoke(loadedConfigs);
        }
    }
}