using Assets._Project.Develop.Runtime.Meta.Infrastructure;
using Assets._Project.Develop.Runtime.UI.Core;

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
        }

        public void Dispose()
        {
        }

        private void LevelSelected()
        {
            _mainMenue.SelectLevel();
        }
    }
}