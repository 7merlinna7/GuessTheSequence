using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.UI.Core.ConfirmPopup
{
    public class ConfirmPopupView : PopupViewBase
    {
        [SerializeField] private TMP_Text _text;

        protected override void ModifyShowAnimation(Sequence animation)
        {
            base.ModifyShowAnimation(animation);
        }
        
        public void SetText(string  text)
        {
            _text.text = text;
        }  
    }
}