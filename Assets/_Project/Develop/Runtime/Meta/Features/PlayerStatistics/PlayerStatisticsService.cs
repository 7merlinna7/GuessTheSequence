using Assets._Project.Develop.Runtime.Utilities.DataManagement;
using Assets._Project.Develop.Runtime.Utilities.DataManagement.DataProviders;

namespace Assets._Project.Develop.Runtime.Meta.Features.PlayerStatistics
{
    public class PlayerStatisticsService : IDataWriter<PlayerData>, IDataReader<PlayerData>
    {
        public int WinsCount { get; private set; }
        public int DefeatsCount { get; private set; }

        public void AddWin() => WinsCount++;
        public void AddDefeat() => DefeatsCount++;

        public PlayerStatisticsService(PlayerDataProvider playerDataProvider)
        {
            playerDataProvider.RegisterWriter(this);
            playerDataProvider.RegisterReader(this);
        }

        public void Reset()
        {
            WinsCount = 0;
            DefeatsCount = 0;
        }

        public void ReadFrom(PlayerData data)
        {
            WinsCount = data.WinsCountData;
            DefeatsCount = data.DefeatCountData;
        }

        public void WriteTo(PlayerData data)
        {
            data.WinsCountData = WinsCount;
            data.DefeatCountData = DefeatsCount;
        }
    }
}