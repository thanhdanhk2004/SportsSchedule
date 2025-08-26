using Microsoft.EntityFrameworkCore;
using SportSchedule.Context;
using SportSchedule.DataModel;
using SportSchedule.DataTranserferObject.Player;
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
                        PlayerId = player_id.MemberId ?? 0,
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

        //Lay thong tin cau thu
        public PlayerInfoDTOFE getPlayer(int player_id)
        {
            try
            {
                if(player_id != null)
                {
                    var data = (from p in _context.Players
                               join m in _context.Members on p.PlayerId equals m.MemberId
                               join mb in _context.TeamMembers on m.MemberId equals mb.MemberId
                               join t in _context.Teams on mb.TeamId equals t.TeamId
                               where p.PlayerId == player_id
                               select new PlayerInfoDTOFE
                               {
                                   PlayerId = p.PlayerId,
                                   Name = m.Name,
                                   Birthday = m.Birthday.ToString(),
                                   Position = m.Position,
                                   Nationaly = m.Nationality,
                                   Height = p.Height,
                                   Weight = p.Weight,
                                   NameCLB = t.Name,
                                   LogoCLB = t.Logo,
                                   Image = m.Image,
                                   Number = p.Number,
                                   Age = m.Age
                               }).FirstOrDefault();
                    return data;
                }
                return null;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null!;
            }
        }

        //Lay thong tin xem thu cau thu da co day du thong tin hay chua
        public string getWeightPlayer(int player_id)
        {
            try 
            {
                if(player_id != null)
                {
                    return _context.Players
                        .Where(p => p.PlayerId == player_id)
                        .Select(p => p.Weight).FirstOrDefault()!;
                }
                return null!;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return "";
            }
        }

        //Cap nhat thong tin cau thu
        public void updateInfoPlayer(int player_id, InfoDataMember info_player)
        {
            try
            {
                if(player_id != null)
                {
                    var player = _context.Players.Where(p => p.PlayerId == player_id).FirstOrDefault();
                    if(player != null)
                    {
                        player.Height = info_player.Height;
                        player.Weight = info_player.Weight;
                    }
                    _context.Players.Update(player);
                    _context.SaveChanges();
                    var member = _context.Members.Where(p => p.MemberId == player_id).FirstOrDefault();
                    if(member != null)
                    {
                        member.Birthday = TimeZoneInfo.ConvertTimeToUtc(info_player.Birthday, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"));
                        member.Image = info_player.Image;
                        member.Age = info_player.Age;
                        member.Nationality = info_player.Nationaly;
                    }
                    _context.Members.Update(member);
                    _context.SaveChanges();
                    return;
                }
                return;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }
        }
    }
}
