using Microsoft.Extensions.Caching.Memory;
using SportSchedule.Context;
using SportSchedule.DataTranserferObject.Card;
using SportSchedule.DataTranserferObject.Fixture;
using SportSchedule.DataTranserferObject.Goal;
using SportSchedule.DataTranserferObject.Player;
using SportSchedule.DataTranserferObject.Statistic;
using SportSchedule.DataTranserferObject.Substitution;
using SportSchedule.Model;

namespace SportSchedule.DataAccess
{
    public class MatchStatisticDAL
    {
        private readonly ContextDB _context;
        public MatchStatisticDAL(ContextDB context)
        {
            _context = context;
        }

        public void addMatchStatistic(FixtureStatisticData data, int? team_id, int? match_id)
        {
            MatchStatictisModel model = new MatchStatictisModel
            {
                Score = data.Score,
                Possession = data.Possession,
                ShortsOnTaget = data.ShotsOnGoal,
                Corners = data.Corner,
                YellowCard = data.YellowCard,
                RedCard = data.RedCard,
                TeamId = team_id,
                MatchId = match_id,
                Lineup = "4-4-3"
            };
            _context.MatchStatictis.Add(model);
            _context.SaveChanges();
        }


        public StatisticDTO getMatchStatistic(int match_id)
        {
            try
            {
                var data = (from m in _context.Matches
                            join l in _context.Leagues on m.LeagueId equals l.LeagueId
                            // Doi nha
                            join th in _context.Teams on m.TeamIdHome equals th.TeamId
                            join ta in _context.Teams on m.TeamIdAway equals ta.TeamId
                            join msh in _context.MatchStatictis
                            on new { m.MatchId, th.TeamId } equals new { msh.MatchId, msh.TeamId }
                            join msa in _context.MatchStatictis
                            on new { m.MatchId, ta.TeamId } equals new { msa.MatchId, msa.TeamId }
                            join pm in _context.PlayerMatchModels on m.MatchId equals pm.MatchId
                            where m.MatchId == match_id
                            select new StatisticDTO
                            {
                                LeagueName = l.Name,
                                NameHome = th.Name,
                                NameAway = ta.Name,
                                Time = m.Time.ToString(),
                                LogoHome = th.Logo,
                                LogoAway = ta.Logo,
                                GoalHomeFullTime = msh.Score,
                                GoalAwayFullTime = msa.Score,
                                StatisticTeamHome = new StatisticDTOFE
                                {
                                    Processing = msh.Possession,
                                    ShortOnGoal = msh.ShortsOnTaget,
                                    Corners = msh.Corners,
                                    YellowCards = msh.YellowCard,
                                    RedCare = msh.RedCard,
                                    TeamId = msh.TeamId,
                                    LineUp = msh.Lineup
                                },
                                StatisticTeamAway = new StatisticDTOFE
                                {
                                    Processing = msa.Possession,
                                    ShortOnGoal = msa.ShortsOnTaget,
                                    Corners = msa.Corners,
                                    YellowCards = msa.YellowCard,
                                    RedCare = msa.RedCard,
                                    TeamId = msa.TeamId,
                                    LineUp = msa.Lineup
                                },
                                GoalHomeFirst = _context.Periods
                                                .Where(p => p.MatchId == m.MatchId && p.Name == "first")
                                                .Select(p => p.GoalHome)
                                                .FirstOrDefault(),
                                GoalAwayFirst = _context.Periods
                                                .Where(p => p.MatchId == m.MatchId && p.Name == "first")
                                                .Select(p => p.GoalAway)
                                                .FirstOrDefault(),
                            }).FirstOrDefault();
                data.PlayerHome = this.getPlayers(data.NameHome!);
                data.PlayerAway = this.getPlayers(data.NameAway!);
                data.CardsHome = this.getCards(match_id, data.NameHome!);
                data.CardsAway = this.getCards(match_id, data.NameAway!);
                data.SubHome = this.getSubs(match_id, data.NameHome!);
                data.SubAway = this.getSubs(match_id, data.NameAway!);
                data.GoalHome = this.getGoals(match_id, data.NameHome!);
                data.GoalAway = this.getGoals(match_id, data.NameAway!);
                return data;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null!;
            }
        }

        public List<PlayerDTOFE> getPlayers(string team_name)
        {
            try
            {
                List<PlayerDTOFE> list_player = (from mb in _context.Members
                                                 join tmb in _context.TeamMembers on mb.MemberId equals tmb.MemberId
                                                 join t in _context.Teams on tmb.TeamId equals t.TeamId
                                                 join p in _context.Players on mb.MemberId equals p.PlayerId into groupPlayer
                                                 from player in groupPlayer.DefaultIfEmpty()
                                                 join pm in _context.PlayerMatchModels on player.PlayerId equals pm.PlayerId into groupPlayerMatch
                                                 from playerMatch in groupPlayerMatch.DefaultIfEmpty()
                                                 where t.Name == team_name
                                                 select new PlayerDTOFE
                                                 {
                                                     Id = mb.MemberId,
                                                     Name = mb.Name,
                                                     Position = mb.Position,
                                                     Status = playerMatch.Status,
                                                     Number = player.Number,
                                                 }).ToList();
                return list_player;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null!;
            }
        }
        public List<SubstitutionDTOFE> getSubs(int match_id, string team)
        {
            try
            {
                List<SubstitutionDTOFE> SubAway = (from s in _context.Substitutions
                                                   join pi in _context.Players on s.PlayerInId equals pi.PlayerId
                                                   join mi in _context.Members on pi.PlayerId equals mi.MemberId
                                                   join po in _context.Players on s.PlayerOutId equals po.PlayerId
                                                   join mo in _context.Members on po.PlayerId equals mo.MemberId
                                                   join tb in _context.TeamMembers on mi.MemberId equals tb.MemberId
                                                   join t in _context.Teams on tb.TeamId equals t.TeamId
                                                   where s.MatchId == match_id && t.Name == team
                                                   select new SubstitutionDTOFE
                                                   {
                                                       Time = s.Time,
                                                       NameIn = mi.Name,
                                                       NameOut = mo.Name
                                                   }).ToList();
                return SubAway;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }

        }

        public List<CardDTOFE> getCards(int match_id, string team_name)
        {
            try
            {
                List<CardDTOFE> listCards = (from c in _context.Cards
                                             join mb in _context.Members on c.MemberId equals mb.MemberId
                                             join tmbh in _context.TeamMembers on mb.MemberId equals tmbh.MemberId
                                             join team in _context.Teams on tmbh.TeamId equals team.TeamId
                                             where c.MatchId == match_id && team.Name == team_name
                                             select new CardDTOFE
                                             {
                                                 NameMember = mb.Name,
                                                 Type = c.TypeCard,
                                                 Time = c.Time,
                                             }).ToList();
                return listCards;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null!;
            }
        }

        public List<GoalDTOFE> getGoals(int match_id, string team_name)
        {
            try
            {
                List<GoalDTOFE> listGoals = (from g in _context.Goals
                                             join p in _context.Players on g.PlayerId equals p.PlayerId
                                             join m in _context.Members on p.PlayerId equals m.MemberId
                                             join t in _context.Teams on g.TeamId equals t.TeamId
                                             where g.MatchId == match_id && t.Name == team_name
                                             select new GoalDTOFE
                                             {
                                                 NamePlayer = m.Name,
                                                 Type = g.GoalType,
                                                 Time = g.GoalTime,
                                             }).ToList();
                return listGoals;
            }
            catch( Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null!;
            }
        }

        public void updateLineUp(int match_id, int team_id, string lineup)
        {
            try 
            {
                if (match_id == null || team_id == null)
                    return;
                var statictisMatch = _context.MatchStatictis
                                    .Where(ms => ms.MatchId == match_id && ms.TeamId == team_id)
                                    .FirstOrDefault();
                if (statictisMatch == null)
                    return;
                statictisMatch.Lineup = lineup;
                _context.MatchStatictis.Update(statictisMatch);
                _context.SaveChanges();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }
        }
    }
}
