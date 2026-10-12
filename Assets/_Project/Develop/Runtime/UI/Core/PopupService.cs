using Assets._Project.Develop.Runtime.UI.Core.TestPopup;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.UI.Core
{
    public abstract class PopupService : MonoBehaviour,IDisposable
    {
        protected readonly ViewsFactory ViewsFactory;

        private readonly ProjectPresentersFactory _presentersFactory;

        private readonly Dictionary<PopupPresenterBase, PopupViewBase> _presenterToView;

        protected PopupService(
            ViewsFactory viewsFactory,
            ProjectPresentersFactory presentersFactory)
        {
            ViewsFactory = viewsFactory;
            _presentersFactory = presentersFactory;
        }

        protected abstract Transform PopupLayer {  get; }

        public void Dispose()
        {
            foreach (PopupPresenterBase popup in _presenterToView.Keys)
            {
                popup.CloseRequest -= ClosePopup;
                DisposeFor(popup);
            }
        }

        public TestPopupPresenter OpenTestPopup()
        {
            TestPopupView view = ViewsFactory.Create<TestPopupView>(ViewIDs.TestPopup,PopupLayer);
            TestPopupPresenter popup = _presentersFactory.CreateTestPopupPresenter(view);

            OnPopupCreated(popup,view);

            return popup;
        }

        protected void OnPopupCreated(
            PopupPresenterBase popup,
            PopupViewBase view)
        {
            popup.Initialize();
            popup.Show();
            _presenterToView.Add(popup, view);

            popup.CloseRequest += ClosePopup;
        }

        private void ClosePopup(PopupPresenterBase popup)
        {
            popup.CloseRequest -= ClosePopup;
            popup.Hide(() =>
            {
                DisposeFor(popup);
                _presenterToView.Remove(popup);
            });
        }

        private void DisposeFor(PopupPresenterBase popup)
        {
            popup.Dispose();
            ViewsFactory.Release(_presenterToView[popup]);
        }
    }
}