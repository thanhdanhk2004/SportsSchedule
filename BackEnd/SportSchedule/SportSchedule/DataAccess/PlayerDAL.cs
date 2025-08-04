using Microsoft.EntityFrameworkCore;
using SportSchedule.Context;
using SportSchedule.DataModel;
using SportSchedule.Model;

namespace SportSchedule.DataAccess
{
    public class PlayerDAL
    {
        private readonly ContextDB _context;
        public PlayerDAL(ContextDB context, MemberDAL memberDAL)
        {
            _context = context;
        }

        public void addPlayer(InfoDataMember model)
        {
            try
            {
                var player_id = _context.Members.AsNoTracking().FirstOrDefault(m => m.MemberId == model.Id); // Bo theo doi cai member da co Id giong
                if(player_id != null)
                {
                    PlayerModel player = new PlayerModel
                    {
                        PlayerId = model.Id,
                        Height = model.Height,
                        Weight = model.Weight,
                        status = true,
                        Number = model.Number,
                    };
                    _context.Players.Add(player);
                    _context.SaveChanges();
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
       
        public bool isExistedPlayer(int player_id)
        {
            return _context.Players.Any(p => p.PlayerId == player_id);
        }
    }
}
