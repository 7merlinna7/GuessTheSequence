using Assets._Project.Develop.Runtime.Meta.Infrastructure;
using Assets._Project.Develop.Runtime.UI.Core;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.UI.CommonViews.LevelSelection
{
    public class LevelSelectionPresenter : IPresenter
    {
        private readonly LevelSelectionView _view;
        private readonly MainMenu _mainMenue;

        public LevelSelectionPresenter(LevelSelectionView view, MainMenu mainMenue)
        {
            _view = view;
            _mainMenue = mainMenue;
        }

        public void Initialize()
        {
            _view.LevelSelected += LevelSelected;
        }

        public void Dispose()
        {
            _view.LevelSelected -= LevelSelected;
        }

        private void LevelSelected(SequenceType levelType)
        {
            _mainMenue.SelectLevel(levelType);
        }
    }
}