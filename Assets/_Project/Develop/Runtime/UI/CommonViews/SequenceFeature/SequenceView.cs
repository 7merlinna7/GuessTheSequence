using Assets._Project.Develop.Runtime.UI.Core;
using TMPro;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.UI.CommonViews.SequenceFeature
{
    public class SequenceView :MonoBehaviour , IView
    {
        [SerializeField] private TMP_Text _text;

        public void SetText(string text) => _text.text = text;
    }
}