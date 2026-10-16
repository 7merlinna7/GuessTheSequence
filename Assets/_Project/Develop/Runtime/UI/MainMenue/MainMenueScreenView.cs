using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.CommonViews.LevelSelection;
using Assets._Project.Develop.Runtime.UI.Core;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Develop.Runtime.UI.MainMenue
{
    public class MainMenueScreenView : MonoBehaviour, IView
    {
        public event Action ResetStatisticsButtonClicked;

        [field: SerializeField] public TextTextListView StatisticView { get; private set; }
        [field: SerializeField] public IconTextView WalletView { get; private set; }
        [field: SerializeField] public LevelSelectionView LevelSelectionView { get; private set; }

        [SerializeField] private Button _resetStatisticsButton;

        private void OnEnable()
        {
            _resetStatisticsButton.onClick.AddListener(OnResetStatisticsButtonClicked);
        }

        private void OnDisable()
        {
            _resetStatisticsButton.onClick.RemoveListener(OnResetStatisticsButtonClicked);
        }

        private void OnResetStatisticsButtonClicked() => ResetStatisticsButtonClicked?.Invoke();
    }
}