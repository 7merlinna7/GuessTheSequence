using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

namespace Assets._Project.Develop.Runtime.UI.Core
{
    public abstract class PopupViewBase : MonoBehaviour, IShowableView
    {
        public event Action CloseRequest;

        [SerializeField] private CanvasGroup _mainGroup;
        [SerializeField] private Image _anticlicker;
        [SerializeField] private CanvasGroup _body;
        [SerializeField] private PopupsAnimationTypes _animationType;

        private float _anticlickerDefaultAlpha;
        private Tween _currentAnimation;
        public void OnCloseButtonClick() => CloseRequest?.Invoke();

        private void Awake()
        {
            _anticlickerDefaultAlpha = _anticlicker.color.a;
            _mainGroup.alpha = 0;
        }

        public Tween Hide()
        {
            KillCurrentAnimation();

            OnPreHide();

            Sequence animation = PopupAnimationCreator.
                CreateHideAnimation(_body, _anticlicker, _animationType, _anticlickerDefaultAlpha);

            ModifyHideAnimation(animation);

            animation.OnComplete(OnPostHide);

            return _currentAnimation = animation.SetUpdate(true).Play();
        }

        public Tween Show()
        {
            KillCurrentAnimation();

            OnPreShow();

            _mainGroup.alpha = 1;

            Sequence animation = PopupAnimationCreator.
                CreateShowAnimation(_body, _anticlicker,_animationType,_anticlickerDefaultAlpha);

            ModifyShowAnimation(animation);

            animation.OnComplete(OnPostShow);

            return _currentAnimation = animation.SetUpdate(true).Play();
        }

        protected virtual void ModifyShowAnimation (Sequence animation) { }
        protected virtual void ModifyHideAnimation (Sequence animation) { }

        protected virtual void OnPostHide() { }

        protected virtual void OnPreHide() { }

        protected virtual void OnPostShow() { }

        protected virtual void OnPreShow() { }

        private void OnDestroy() => KillCurrentAnimation();

        private void KillCurrentAnimation()
        {
            if (_currentAnimation != null)
                _currentAnimation.Kill();
        }
    }
}