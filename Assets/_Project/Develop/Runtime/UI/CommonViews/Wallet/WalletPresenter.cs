using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.UI.Core;

namespace Assets._Project.Develop.Runtime.UI.CommonViews.Wallet
{
    public class WalletPresenter : IPresenter
    {
        private readonly ProjectPresentersFactory _projectPresentersFactory;
        private readonly IconTextView _view;
        private readonly WalletService _wallet;

        private CurrencyPresenter _currencyGoldPresenter;

        public WalletPresenter(ProjectPresentersFactory projectPresentersFactory, IconTextView view, WalletService wallet)
        {
            _projectPresentersFactory = projectPresentersFactory;
            _view = view;
            _wallet = wallet;
        }

        public void Initialize()
        {
            CreateCurrencyBy(CurrencyTypes.Gold);
        }

        public void Dispose()
        {
            _currencyGoldPresenter?.Dispose();
            _currencyGoldPresenter = null;
        }

        private void CreateCurrencyBy(CurrencyTypes currencyType)
        {
            _currencyGoldPresenter = _projectPresentersFactory.CreateCurrencyPresenter(_view, _wallet.GetCurrency(currencyType), currencyType);
            _currencyGoldPresenter.Initialize();
        }
    }
}