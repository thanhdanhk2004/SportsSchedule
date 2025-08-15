using Microsoft.EntityFrameworkCore;
using SportSchedule.Context;
using SportSchedule.DataTranserferObject.League;

namespace SportSchedule.DataAccess
{
    public class LeagueDAL
    {
        private readonly ContextDB _context;
        public LeagueDAL(ContextDB context)
        {
            _context = context;
        }

        public List<LeagueDTOFE> getLeagues(List<string> leagues)
        {
            try
            {
                var data = _context.Leagues
                .Where(l => leagues.Contains(l.Name!) && l.Country != "Brazil")
                .Select(l => new LeagueDTOFE
                {
                    Id = l.LeagueId,
                    Name = l.Name,
                    Logo = l.Logo,
                }).ToList();
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        
    }
}
