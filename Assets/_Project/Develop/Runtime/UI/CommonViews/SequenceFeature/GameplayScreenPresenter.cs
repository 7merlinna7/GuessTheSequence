using Assets._Project.Develop.Runtime.UI.CommonViews.Gameplay;
using Assets._Project.Develop.Runtime.UI.Core;

namespace Assets._Project.Develop.Runtime.UI.CommonViews.SequenceFeature
{
    public class GameplayScreenPresenter : IPresenter
    {
        private readonly SequenceView _view;
        private readonly GameplayPopupService _popupService;

        public GameplayScreenPresenter(SequenceView view, GameplayPopupService popupService)
        {
            _view = view;
            _popupService = popupService;
        }

        public void Initialize()
        {
        }

        public void Dispose()
        {
        }
    }
}