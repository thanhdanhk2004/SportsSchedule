using SportSchedule.Context;
using SportSchedule.Model;

namespace SportSchedule.DataAccess
{
    public class Period
    {
        private readonly ContextDB _context;
        public Period(ContextDB context)
        {
            _context = context;
        }

        
    }
}
