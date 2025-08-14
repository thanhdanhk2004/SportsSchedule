using SportSchedule.DataTranserferObject.Ranking;

namespace SportSchedule.Services.Ranking
{
    public interface IRankingService
    {
        Task rankCaculation(int league_id);
        Task addRankings();
        Task<List<RankingDTOFE>> getRankings(int league_id, string season);
        Task updateRankings(int match_id);
    }
}
