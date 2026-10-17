using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.MainMenue;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.UI.CommonViews.Gameplay
{
    public class GameplayPopupService : PopupService
    {
        private readonly ScreenUIRoot _uiRoot;

        public GameplayPopupService(
            ViewsFactory viewsFactory,
            ProjectPresentersFactory presentersFactory,
            ScreenUIRoot uiRoot)
            : base(viewsFactory, presentersFactory)
        {
            _uiRoot = uiRoot;
        }

        protected override Transform PopupLayer => _uiRoot.PopupsLayer;
    }
}