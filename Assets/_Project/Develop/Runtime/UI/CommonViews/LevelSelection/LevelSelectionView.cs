using Assets._Project.Develop.Runtime.UI.Core;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.UI.CommonViews.LevelSelection
{
    public class LevelSelectionView : MonoBehaviour,IView
    {
        public event Action<SequenceType> LevelSelected;

        public void NumbersLevelSelected() => LevelSelected.Invoke(SequenceType.Numbers);
        public void LettersLevelSelected() => LevelSelected.Invoke(SequenceType.Letters);
    }
}