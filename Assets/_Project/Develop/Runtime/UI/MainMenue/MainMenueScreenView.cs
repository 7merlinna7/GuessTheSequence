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
        [field: SerializeField] public TextTextListView StatisticView { get; private set; }
        [field: SerializeField] public IconTextView WalletView { get; private set; }


        public event Action OpenTestPopupButtonClicked;

        [SerializeField] private Button _openTestPopupButton;

        private void OnEnable()
        {
            _openTestPopupButton.onClick.AddListener(OnOpenTestPopupButtonClicked);
        }

        private void OnDisable()
        {
            _openTestPopupButton.onClick.RemoveListener(OnOpenTestPopupButtonClicked);
        }

        private void OnOpenTestPopupButtonClicked()
        {
            OpenTestPopupButtonClicked?.Invoke();
        }
    }
}