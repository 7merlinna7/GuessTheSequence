using Assets._Project.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.MainMenue;
using System;

namespace Assets._Project.Develop.Runtime.UI.CommonViews.SequenceFeature
{
    public class GameplayScreenPresenter : IPresenter
    {
        private readonly SequenceView _view;
        private readonly GameCycle _gameCycle;
        private readonly MainMenuePopupService _popupService;

        public GameplayScreenPresenter(SequenceView view, GameCycle gameCycle, MainMenuePopupService popupService)
        {
            _view = view;
            _gameCycle = gameCycle;
            _popupService = popupService;
        }

        public void Initialize()
        {
            _gameCycle.GameplayResult += OpenConfirmPopup;
            _gameCycle.SequenceCreated += SetSequence;
        }

        public void Dispose()
        {
            _gameCycle.GameplayResult -= OpenConfirmPopup;
            _gameCycle.SequenceCreated -= SetSequence;
        }

        private void SetSequence(string sequence) => _view.SetText(sequence);

        private void OpenConfirmPopup(string text,Action callback)
        {
            _popupService.OpenConfirmPopup(callback).SetPopupText(text);
        }
    }
}