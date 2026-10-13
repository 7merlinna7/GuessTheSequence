using Assets._Project.Develop.Runtime.UI.Core;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.UI.CommonViews
{
    public class TextTextView : MonoBehaviour,IView
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private TMP_Text _name;

        public void SetText(string text) => _text.text = text;
        public void SetName(string text) => _name.text = text;
    }
}