using System;
using UnityEngine;
using DG.Tweening;

namespace Assets._Project.Develop.Runtime.UI.Core
{
    public abstract class PopupViewBase : MonoBehaviour, IShowableView
    {
        public event Action CloseRequest;

        [SerializeField] private CanvasGroup _mainGroup;
        [SerializeField] private Transform _body;
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
            _body.DOScale(1, 0.5f).From(0);
            OnPostShow();
        }

        protected virtual void OnPostHide() { }

        protected virtual void OnPreHide() { }

        protected virtual void OnPostShow() { }

        protected virtual void OnPreShow() { }
    }
}