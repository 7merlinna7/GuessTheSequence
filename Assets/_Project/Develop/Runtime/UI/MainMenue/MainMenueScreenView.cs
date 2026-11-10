using Assets._Project.Develop.Runtime.UI.CommonViews;
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
        public event Action PlayButtonClicked;

        [field: SerializeField] public TextTextListView StatisticView { get; private set; }
        [field: SerializeField] public IconTextView WalletView { get; private set; }

        [SerializeField] private Button _resetStatisticsButton;
        [SerializeField] private Button _playButton;

        private void OnEnable()
        {
            _resetStatisticsButton.onClick.AddListener(OnResetStatisticsButtonClicked);
            _playButton.onClick.AddListener(OnPlayButtonClicked);
        }

        private void OnDisable()
        {
            _resetStatisticsButton.onClick.RemoveListener(OnResetStatisticsButtonClicked);
            _playButton.onClick.RemoveListener (OnPlayButtonClicked);
        }

        private void OnResetStatisticsButtonClicked() => ResetStatisticsButtonClicked?.Invoke();

        private void OnPlayButtonClicked() => PlayButtonClicked?.Invoke();
    }
}