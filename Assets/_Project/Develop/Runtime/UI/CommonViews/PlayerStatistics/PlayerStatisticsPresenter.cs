using Assets._Project.Develop.Runtime.Meta.Features.PlayerStatistics;
using Assets._Project.Develop.Runtime.UI.Core;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.UI.CommonViews.PlayerStatistics
{
    public class PlayerStatisticsPresenter : IPresenter
    {
        private readonly PlayerStatisticsService _playerStatistics;
        private readonly ProjectPresentersFactory _projectPresentersFactory;
        private readonly ViewsFactory _viewsFactory;
        private readonly List<StatisticPresenter> _statisticsPresenters = new();

        private readonly TextTextListView _view;

        public PlayerStatisticsPresenter(
            PlayerStatisticsService playerStatistics,
            ProjectPresentersFactory projectPresentersFactory,
            ViewsFactory viewsFactory,
            TextTextListView view)
        {
            _playerStatistics = playerStatistics;
            _projectPresentersFactory = projectPresentersFactory;
            _viewsFactory = viewsFactory;
            _view = view;
        }

        public void Initialize()
        {
            CreateStatisticPresenterBy(PlayerStatisticType.Wins, _playerStatistics.WinsCount);
            CreateStatisticPresenterBy(PlayerStatisticType.Defeats, _playerStatistics.DefeatsCount);
        }

        public void Dispose()
        {
            foreach (StatisticPresenter statisticPresenter in _statisticsPresenters)
            {
                _view.Remove(statisticPresenter.View);
                _viewsFactory.Release(statisticPresenter.View);
                statisticPresenter.Dispose();
            }

            _statisticsPresenters.Clear();
        }

        private void CreateStatisticPresenterBy(PlayerStatisticType playerStatisticType, int value)
        {
            TextTextView view = _viewsFactory.Create<TextTextView>(ViewIDs.StatisticView);
            _view.Add(view);
            StatisticPresenter presenter = _projectPresentersFactory.CreateStatisticsPresenter(value, playerStatisticType, view);
            presenter.Initialize();
            _statisticsPresenters.Add(presenter);
        }
    }
}