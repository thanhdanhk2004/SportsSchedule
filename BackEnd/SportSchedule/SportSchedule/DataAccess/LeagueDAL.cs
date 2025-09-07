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

        public List<string> getLeaguesCode()
        {
            try
            {
                return _context.Leagues.Select(l => l.Code).ToList()!;
            }catch (Exception ex)
            {
                return null!;
            }
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
        
        //Chuc nang cua admin
        //Lay cac giai dau do ra admin
        public List<LeagueDTOFEAdmin> getLeaguesAdmin()
        {
            try
            {
                var data = _context.Leagues
                    .Select(l => new LeagueDTOFEAdmin
                    {
                        LeagueId = l.LeagueId,
                        LeagueName = l.Name,
                        Country = l.Country,
                        Logo = l.Logo
                    }).ToList();
                return data;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null!;
            }
        }

        //Xoa giai dau
        public bool deleteLeague(int leagueId)
        {
            try
            {
                if (leagueId == null)
                    return false;
                var league = _context.Leagues.FirstOrDefault(l => l.LeagueId == leagueId);
                if(league == null) return false;

                _context.Leagues.Remove(league);
                _context.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }


    }
}
