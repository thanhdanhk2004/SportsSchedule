using SportSchedule.Context;
using SportSchedule.DataModel;
using SportSchedule.Model;

namespace SportSchedule.DataAccess
{
    public class PlayerDAL
    {
        private readonly ContextDB _context;
        private readonly MemberDAL _memberDAL;
        public PlayerDAL(ContextDB context, MemberDAL memberDAL)
        {
            _context = context;
            _memberDAL = memberDAL;
        }

        public void addPlayer(InfoDataMember model)
        {
            try
            {
                _memberDAL.addMember(model);
                PlayerModel player = new PlayerModel
                {
                    MemberId = model.Id,
                    Height = model.Height,
                    Weight = model.Weight,
                    status = true,
                    Number = model.Number,
                };
                _context.Players.Add(player);
                _context.SaveChanges();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
       
        public bool isExistedPlayer(int player_id)
        {
            return _context.Players.Any(p => p.MemberId == player_id);
        }
    }
}
