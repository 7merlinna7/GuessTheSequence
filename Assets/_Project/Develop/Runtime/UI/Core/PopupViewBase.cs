using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.UI.Core
{
    public abstract class PopupViewBase : MonoBehaviour, IShowableView
    {
        public event Action CloseRequest;

        [SerializeField] private CanvasGroup _mainGroup;
        public void OnCloseButtonClick() => CloseRequest?.Invoke();

        private void Awake()
        {
            _mainGroup.alpha = 0;
        }

        public void Hide()
        {
            OnPreHide();
            _mainGroup.alpha = 0;
            OnPostHide();
        }

        public void Show()
        {
            OnPreShow();
            _mainGroup.alpha = 1;
            OnPostShow();
        }

        protected virtual void OnPostHide() { }

        protected virtual void OnPreHide() { }

        protected virtual void OnPostShow() { }

        protected virtual void OnPreShow() { }
    }
}