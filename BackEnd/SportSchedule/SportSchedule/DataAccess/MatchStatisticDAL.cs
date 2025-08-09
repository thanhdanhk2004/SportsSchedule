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
                MatchId = match_id
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
                                    TeamId = msh.TeamId
                                },
                                StatisticTeamAway = new StatisticDTOFE
                                {
                                    Processing = msa.Possession,
                                    ShortOnGoal = msa.ShortsOnTaget,
                                    Corners = msa.Corners,
                                    YellowCards = msa.YellowCard,
                                    RedCare = msa.RedCard,
                                    TeamId = msa.TeamId
                                },
                                GoalHomeFirst = _context.Periods
                                                .Where(p => p.MatchId == m.MatchId && p.Name == "first")
                                                .Select(p => p.GoalHome)
                                                .FirstOrDefault(),
                                GoalAwayFirst = _context.Periods
                                                .Where(p => p.MatchId == m.MatchId && p.Name == "first")
                                                .Select(p => p.GoalAway)
                                                .FirstOrDefault(),
                                PlayerHome = (from mbh in _context.Members
                                              join tmbh in _context.TeamMembers on mbh.MemberId equals tmbh.MemberId
                                              join p in _context.Players on mbh.MemberId equals p.PlayerId into groupPlayer
                                              from player in groupPlayer.DefaultIfEmpty()
                                              join pm in _context.PlayerMatchModels on player.PlayerId equals pm.PlayerId
                                              where tmbh.TeamId == th.TeamId
                                              select new PlayerDTOFE
                                              {
                                                  Id = mbh.MemberId,
                                                  Name = mbh.Name,
                                                  Position = mbh.Position,
                                                  Status = pm.Status
                                              }).ToList(),

                                PlayerAway = (from mba in _context.Members
                                              join tmba in _context.TeamMembers on mba.MemberId equals tmba.MemberId
                                              join p in _context.Players on mba.MemberId equals p.PlayerId into groupPlayer
                                              from player in groupPlayer.DefaultIfEmpty()
                                              join pm in _context.PlayerMatchModels on player.PlayerId equals pm.PlayerId
                                              where tmba.TeamId == th.TeamId
                                              select new PlayerDTOFE
                                              {
                                                  Id = mba.MemberId,
                                                  Name = mba.Name,
                                                  Position = mba.Position,
                                                  Status = pm.Status
                                              }).ToList(),
                                GoalHome = (from g in _context.Goals
                                            join p in _context.Players on g.PlayerId equals p.PlayerId
                                            join mb in _context.Members on p.PlayerId equals mb.MemberId
                                            where g.MatchId == m.MatchId && g.TeamId == th.TeamId
                                            select new GoalDTOFE
                                            {
                                                NamePlayer = mb.Name,
                                                Type = g.GoalType,
                                                Time = g.GoalTime,
                                            }).ToList(),
                                GoalAway = (from g in _context.Goals
                                            join p in _context.Players on g.PlayerId equals p.PlayerId
                                            join mb in _context.Members on p.PlayerId equals mb.MemberId
                                            where g.MatchId == m.MatchId && g.TeamId == ta.TeamId
                                            select new GoalDTOFE
                                            {
                                                NamePlayer = mb.Name,
                                                Type = g.GoalType,
                                                Time = g.GoalTime,
                                            }).ToList(),
                                CardsHome = (from c in _context.Cards
                                             join mb in _context.Members on c.MemberId equals mb.MemberId
                                             join tmbh in _context.TeamMembers on mb.MemberId equals tmbh.MemberId
                                             join teamHome in _context.Teams on tmbh.TeamId equals teamHome.TeamId
                                             where c.MatchId == m.MatchId
                                             select new CardDTOFE
                                             {
                                                 NameMember = mb.Name,
                                                 Type = c.TypeCard,
                                                 Time = c.Time,
                                             }).ToList(),
                                CardsAway = (from c in _context.Cards
                                             join mb in _context.Members on c.MemberId equals mb.MemberId
                                             join tmba in _context.TeamMembers on mb.MemberId equals tmba.MemberId
                                             join teamAway in _context.Teams on tmba.TeamId equals teamAway.TeamId
                                             where c.MatchId == m.MatchId
                                             select new CardDTOFE
                                             {
                                                 NameMember = mb.Name,
                                                 Type = c.TypeCard,
                                                 Time = c.Time,
                                             }).ToList(),
                                //Cach tu lam 
                                SubHome = (from c in _context.Substitutions
                                           join pi in _context.Players on c.PlayerInId equals pi.PlayerId
                                           join mi in _context.Members on pi.PlayerId equals mi.MemberId
                                           join po in _context.Players on c.PlayerOutId equals po.PlayerId
                                           join mo in _context.Members on po.PlayerId equals mo.MemberId
                                           where c.MatchId == m.MatchId
                                           select new SubstitutionDTOFE
                                           {
                                               Time = c.Time,
                                               NameIn = mi.Name,
                                               NameOut = mo.Name
                                           }).ToList(),
                                //Cach chatgpt huong dan
                                SubAway = (_context.Substitutions
                                            .Where(s => s.MatchId == m.MatchId)
                                            .Select(s => new SubstitutionDTOFE
                                            {
                                                Time = s.Time,
                                                NameIn = s.PlayerIn.Member.Name,
                                                NameOut = s.PlayerOut.Member.Name
                                            }).ToList())

                            }).FirstOrDefault();
                           

                return data;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
