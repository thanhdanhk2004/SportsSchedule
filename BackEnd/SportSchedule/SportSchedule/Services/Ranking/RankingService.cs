using SportSchedule.DataAccess;
using SportSchedule.DataTranserferObject.Ranking;
using Microsoft.Extensions.Caching.Memory;

namespace SportSchedule.Services.Ranking
{
    public class RankingService : IRankingService
    {
        private readonly RankingDAL _rankingDAL;
        private readonly IMemoryCache _cache;
        public RankingService(RankingDAL rankingDAL, IMemoryCache cache)
        {
            _rankingDAL = rankingDAL;
            _cache = cache;
        }

        //Them bang xep hang cho mot mua giai
        public async Task addRankings()
        {
            _rankingDAL.addRanking();
            return;
        }

        //Lay bang xep hang cho FE
        public async Task<List<RankingDTOFE>> getRankings(int league_id, string season)
        {
            string key_cache = $"Ranking_{league_id}_{season}";
            if (_cache.TryGetValue(key_cache, out List<RankingDTOFE>? result))
                return result;
            var data = _rankingDAL.getRanking(league_id, season);
            if(data != null) 
                _cache.Set(key_cache, data, TimeSpan.FromHours(1));
            return data;
        }

        //Tinh toan bang xep hang
        public Task rankCaculation(int league_id)
        {
            throw new NotImplementedException();
        }


        public async Task updateRankings(int match_id)
        {
            _rankingDAL.updateRanking(match_id);
            return;
        }
    }
}
