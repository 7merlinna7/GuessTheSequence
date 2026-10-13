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
            //wins
            TextTextView winsView = _viewsFactory.Create<TextTextView>(ViewIDs.StatisticView);
            _view.Add(winsView);
            StatisticPresenter winsPresenter = _projectPresentersFactory.CreateStatisticsPresenter(_playerStatistics.WinsCount, PlayerStatisticType.Wins, winsView);
            winsPresenter.Initialize();
            _statisticsPresenters.Add(winsPresenter);

            //defeats
            TextTextView defeatsView = _viewsFactory.Create<TextTextView>(ViewIDs.StatisticView);
            _view.Add(defeatsView);
            StatisticPresenter defeatsPresenter = _projectPresentersFactory.CreateStatisticsPresenter(_playerStatistics.DefeatsCount, PlayerStatisticType.Defeats, defeatsView);
            defeatsPresenter.Initialize();
            _statisticsPresenters.Add(defeatsPresenter);
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
    }
}