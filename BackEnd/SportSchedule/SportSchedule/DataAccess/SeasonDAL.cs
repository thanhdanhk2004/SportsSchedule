using SportSchedule.Context;
using SportSchedule.Model;

namespace SportSchedule.DataAccess
{
    public class SeasonDAL
    {
        private readonly ContextDB _context;
        public SeasonDAL(ContextDB context)
        {
            _context = context;
        }

        public bool getSeason()
        {
            try
            {
                return _context.Seasons.Any(s => s.SeasonYear == DateTime.Now.Year.ToString());
            }catch (Exception ex)
            {
                return false;
            }
        }

        public bool addSeason()
        {
            try
            {
                SeasonModel season = new SeasonModel
                {
                    SeasonYear = DateTime.Now.Year.ToString(),
                };
                _context.Seasons.Add(season);
                _context.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }


    }
}
