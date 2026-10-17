using Assets._Project.Develop.Runtime.Configs.Meta.PlayerStatistics;
using Assets._Project.Develop.Runtime.Meta.Features.PlayerStatistics;
using Assets._Project.Develop.Runtime.UI.Core;

namespace Assets._Project.Develop.Runtime.UI.CommonViews.PlayerStatistics
{
    public class StatisticPresenter : IPresenter
    {
        private readonly int _value;
        private readonly PlayerStatisticsStartConfig _statisticsConfig;
        private readonly PlayerStatisticType _playerStatisticType;

        private readonly TextTextView _view;
        public TextTextView View => _view;

        public StatisticPresenter(
            int value,
            PlayerStatisticsStartConfig statisticsConfig,
            PlayerStatisticType playerStatisticType,
            TextTextView view)
        {
            _value = value;
            _statisticsConfig = statisticsConfig;
            _playerStatisticType = playerStatisticType;
            _view = view;
        }

        public void Initialize()
        {
            UpdateValue(_value);
            _view.SetName(_statisticsConfig.GetStatisticNameBy(_playerStatisticType));
        }

        public void Dispose()
        {
            
        }

        public void ResetStatisticValue() => _view.SetText(_statisticsConfig.ResetedValue.ToString());

        private void UpdateValue(int value) => _view.SetText(value.ToString());
        
    }
}