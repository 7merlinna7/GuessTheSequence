using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Develop.Runtime.UI.Core
{
    public class PopupAnimationCreator
    {
        public static Sequence CreateShowAnimation(
            CanvasGroup body,
            Image anticlicker,
            PopupsAnimationTypes animationType,
            float anticklickerMaxAlpha)
        {
            switch (animationType)
            {
                case PopupsAnimationTypes.None:
                    return DOTween.Sequence();
                case PopupsAnimationTypes.Expand:
                    return DOTween.Sequence()
                        .Append(anticlicker
                        .DOFade(anticklickerMaxAlpha, 0.2f)
                        .From(0))
                        .Join(body.transform
                        .DOScale(1, 0.5f)
                        .From(0)
                        .SetEase(Ease.OutBack));
                default:
                    throw new ArgumentException(nameof(animationType));

            }
        }

        public static Sequence CreateHideAnimation(
            CanvasGroup body,
            Image anticlicker,
            PopupsAnimationTypes animationType,
            float anticklickerMaxAlpha)
        {
            return DOTween.Sequence();
        }
    }
}