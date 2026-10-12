using Assets._Project.Develop.Runtime.UI.Core;
using System;

namespace Assets._Project.Develop.Runtime.UI.MainMenue
{
    public class MainMenueScreenPresenter : IPresenter
    {
        MainMenueScreenView _screen;
        private readonly MainMenuePopupService _popupService;

        public MainMenueScreenPresenter(MainMenueScreenView screen, MainMenuePopupService popupService)
        {
            _screen = screen;
            _popupService = popupService;
        }

        public void Initialize()
        {
            _screen.OpenTestPopupButtonClicked += OnOpenTestPopupButtonClicked;
        }


        public void Dispose()
        {
            _screen.OpenTestPopupButtonClicked -= OnOpenTestPopupButtonClicked;
        }

        private void OnOpenTestPopupButtonClicked()
        {
            _popupService.OpenTestPopup();
        }
    }
}