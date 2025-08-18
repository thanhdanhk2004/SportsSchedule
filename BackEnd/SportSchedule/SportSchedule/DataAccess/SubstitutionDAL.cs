using SportSchedule.Context;
using SportSchedule.DataTranserferObject.Substitution;
using SportSchedule.Model;

namespace SportSchedule.DataAccess
{
    public class SubstitutionDAL
    {
        private readonly ContextDB _context;
        private readonly MemberDAL _memberDAL;
        public SubstitutionDAL(ContextDB context, MemberDAL memberDAL)
        {
            _context = context;
            _memberDAL = memberDAL;
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
                        PlayerInId = _memberDAL.isExistedMember(sub.PlayerInId ?? 0) == true?sub.PlayerInId:null,
                        PlayerOutId = _memberDAL.isExistedMember(sub.PlayerOutId ?? 0) == true ? sub.PlayerOutId : null,
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
