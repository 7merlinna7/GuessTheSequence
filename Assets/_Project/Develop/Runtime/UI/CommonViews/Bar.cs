using Assets._Project.Develop.Runtime.UI.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Develop.Runtime.UI.CommonViews
{
    public class Bar : MonoBehaviour,IView
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Image _filter;

        public void UpdateValue (float sliderValue) => _slider.value = sliderValue;

        public void SetFilterColor(Color color) => _filter.color = color;
    }
}