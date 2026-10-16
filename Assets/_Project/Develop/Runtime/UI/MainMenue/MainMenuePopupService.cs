using Assets._Project.Develop.Runtime.UI.Core;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.UI.MainMenue
{
    public class MainMenuePopupService : PopupService
    {
        private readonly ScreenUIRoot _uiRoot;

        public MainMenuePopupService(
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