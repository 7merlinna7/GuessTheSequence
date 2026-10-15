using Assets._Project.Develop.Runtime.Utilites.CoroutinesManagment;

namespace Assets._Project.Develop.Runtime.UI.Core.ConfirmPopup
{
    public class ConfirmPopupPresenter : PopupPresenterBase
    {
        private readonly ConfirmPopupView _view;

        public ConfirmPopupPresenter(ConfirmPopupView view,ICoroutinesPerformer coroutinesPerformer) : base(coroutinesPerformer)
        {
            _view = view;
        }

        protected override PopupViewBase PopupView => _view;

        public void SetPopupText(string text) => _view.SetText(text);
    }
}