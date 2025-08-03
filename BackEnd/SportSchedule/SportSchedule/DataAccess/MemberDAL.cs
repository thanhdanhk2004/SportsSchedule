using SportSchedule.Context;
using SportSchedule.DataModel;
using SportSchedule.Model;

namespace SportSchedule.DataAccess
{
    public class MemberDAL
    {
        private readonly ContextDB _context;
        public MemberDAL(ContextDB context)
        {
            _context = context;
        }
        public void addMember(InfoDataMember model)
        {
            try
            {
                MemberModel member = new MemberModel
                {
                    MemberId = model.Id,
                    Name = model.Name,
                    Nationality = model.Nationaly,
                    Birthday = model.Birthday,
                    Position = model.Position,
                    Age = model.Age,
                    Image = model.Image,

                };
                _context.Members.Add(member);
                _context.SaveChanges();

            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public bool isExistedMember(int member_id)
        {
            return _context.Members.Any(m => m.MemberId == member_id);
        }
    }
}
