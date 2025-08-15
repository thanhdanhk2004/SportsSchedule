using Microsoft.EntityFrameworkCore;
using SportSchedule.Context;
using SportSchedule.DataTranserferObject.Ranking;
using SportSchedule.Model;

namespace SportSchedule.DataAccess
{
    public class RankingDAL
    {
        private readonly ContextDB _context;
        public RankingDAL(ContextDB context)
        {
            _context = context;
        }

        //Them bang xep hang cho mua giai hien tai
        public void addRanking()
        {
            try
            {
                var listTeamLeague = _context.LeagueTeams.ToList();
                var seasonId = _context.Seasons
                    .Where(s => s.SeasonYear == DateTime.Now.Year.ToString())
                    .Select(s => s.SeasonId).FirstOrDefault();
                foreach (var item in listTeamLeague)
                {
                    RankingModel model = new RankingModel
                    {
                        LeagueId = item.LeagueId,
                        TeamId = item.TeamId,
                        SeasonId = seasonId,
                        Played = 0,
                        Win = 0,
                        Draw = 0,
                        Loss = 0,
                        Point = 0,
                    };
                    _context.Rankings.Add(model);
                    _context.SaveChanges();
                }
                return;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }
        }

        //Lay thong tin de cap nhat bang xep hang
        public List<RankingDTO> getInfoFixture(int match_id)
        {
            try { 
                if(match_id != null)
                {
                    var matchStatistic = (from ms in _context.MatchStatictis
                                         join m in _context.Matches on ms.MatchId equals m.MatchId
                                         join l in _context.Leagues on m.LeagueId equals l.LeagueId
                                         where ms.MatchId == match_id
                                         select new RankingDTO
                                         {
                                             TeamId = ms.TeamId,
                                             Score = ms.Score,
                                             LeagueId = l.LeagueId,
                                         }).ToList();
                    return matchStatistic;
                }
                return null;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        //Tinh toan bang xep hang
        public void updateRanking(int match_id)
        {
            try
            {
                if(match_id == null)
                    return;
                List<RankingDTO> list = this.getInfoFixture(match_id);
                if(list == null)
                    return;
                int i = 0;
                var rankingTeamOne = _context.Rankings.
                        Where(r => r.LeagueId == list[0].LeagueId && r.TeamId == list[0].TeamId)
                        .FirstOrDefault();
                var rankingTeamTwo = _context.Rankings.
                        Where(r => r.LeagueId == list[1].LeagueId && r.TeamId == list[1].TeamId)
                        .FirstOrDefault();
                if (rankingTeamOne == null || rankingTeamTwo == null)
                    return;

                rankingTeamOne.Played += 1;
                rankingTeamTwo.Played += 1;
                if (list[0].Score > list[1].Score)
                {
                    rankingTeamOne.Win += 1;
                    rankingTeamTwo.Loss += 1;
                    rankingTeamOne.Point += 3;
                }
                else if(list[0].Score < list[1].Score)
                {
                    rankingTeamOne.Win += 1;
                    rankingTeamTwo.Loss += 1;
                    rankingTeamTwo.Point += 3;
                }
                else
                {
                    rankingTeamOne.Draw += 1;
                    rankingTeamTwo.Draw += 1;
                    rankingTeamOne.Point += 1;
                    rankingTeamTwo.Point += 1;
                }
                rankingTeamOne.Difference = rankingTeamOne.Difference + list[0].Score - list[1].Score;
                rankingTeamOne.Difference = rankingTeamOne.Difference + list[1].Score - list[0].Score;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        //Lay du lieu bang xep hang do ra frontend
        public List<RankingDTOFE> getRanking(int league_id, string season)
        {
            try
            {
                if(league_id == null || season == null)
                    return null;
                int? season_id = _context.Seasons
                       .Where(s => s.SeasonYear == season.ToString())
                        .Select(s =>s.SeasonId).FirstOrDefault();
                var rankings = _context.Rankings.Include(l => l.League)
                            .Where(r => r.LeagueId == league_id && r.SeasonId == season_id)
                            .Select(r => new RankingDTOFE
                            {
                                LeagueName = r.League.Name,
                                TeamId = r.TeamId,
                                TeamName = _context.Teams.Where(t => t.TeamId == r.TeamId).Select(t => t.Name).FirstOrDefault(),
                                Logo = _context.Teams.Where(t => t.TeamId == r.TeamId).Select(t => t.Logo).FirstOrDefault(),
                                Played = r.Played,
                                Win = r.Win,
                                Draw = r.Draw,
                                Loss = r.Loss,
                                Point = r.Point,
                                Difference = r.Difference,

                            }).OrderByDescending(r => r.Point)
                            .ThenByDescending(r => r.Difference)
                            .ThenByDescending(r => r.Win).ToList();
                return rankings;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
