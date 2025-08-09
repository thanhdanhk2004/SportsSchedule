using SportSchedule.Context;
using SportSchedule.DataTranserferObject.Substitution;
using SportSchedule.Model;

namespace SportSchedule.DataAccess
{
    public class SubstitutionDAL
    {
        private readonly ContextDB _context;
        public SubstitutionDAL(ContextDB context)
        {
            _context = context;
        }

        public void addSubstitutionDAL(SubstitutionDTO sub, int match_id)
        {
            try
            {
                if(sub != null)
                {
                    SubstitutionModel model = new SubstitutionModel
                    {
                        Time = sub.Time,
                        MatchId = match_id,
                        PlayerInId = sub.PlayerInId,
                        PlayerOutId = sub.PlayerOutId,
                    };
                    _context.Substitutions.Add(model);
                    _context.SaveChanges();
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
