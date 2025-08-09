
using Newtonsoft.Json.Linq;
using SportSchedule.Context;
using SportSchedule.DataAccess;
using SportSchedule.DataModel;
using System.Threading.Tasks;

namespace SportSchedule.Services.Member
{
    public class MemberService : IMemberService
    {
        private readonly HttpClient _httpClient;
        private readonly MemberDAL _memberDAL;
        private readonly PlayerDAL _playerDAL;
        private readonly PlayerMatchDAL _playerMatchDAL;
        private readonly TeamMemberDAL _teamMemberDAL;
        public MemberService(ContextDB context, IHttpClientFactory httpClient, MemberDAL member, PlayerDAL playerDAL, PlayerMatchDAL playerMatchDAL, TeamMemberDAL teamMemberDAL)
        {
            _httpClient = httpClient.CreateClient("FootballAPI");
            _memberDAL = member;
            _playerDAL = playerDAL;
            _playerMatchDAL = playerMatchDAL;
            _teamMemberDAL = teamMemberDAL;
        }
        public async Task getMemberService(int fixture_id, int team_home_id, int team_away_id, int match_id)
        {
            var response_lineup = await _httpClient.GetAsync($"fixtures/lineups?fixture={fixture_id}");
            response_lineup.EnsureSuccessStatusCode();

            var content = await response_lineup.Content.ReadAsStringAsync();
            var json = JObject.Parse(content);

            int i = 0;
            foreach(var item  in json["response"]!)
            {
                int coach_id = (int)item["coach"]?["id"]!;
                //Kiem tra co ton tai HLV hay chua
                if(!_memberDAL.isExistedMember(coach_id))
                    await this.addInfoCoach(coach_id);
                foreach(var player in item["startXI"]!)
                {
                    int player_id = (int)player["player"]?["id"]!;
                    //Kiem tra co ton tai cau thu hay chua neu chua thi moi them
                    if (!_playerDAL.isExistedPlayer(player_id))
                    {
                        InfoDataMember info = new InfoDataMember
                        {
                            Id = player_id,
                            Name = (string)player["player"]?["name"]!,
                            Number = (int)player["player"]?["number"]!,
                            Position = (string)player["player"]?["pos"]!,
                            Birthday = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified),
                            Nationaly = "",
                            Age = 0,
                            Weight = "0 kg",
                            Height = "0 cm",
                            Image = "",
                        };
                        _memberDAL.addMember(info);
                        _playerDAL.addPlayer(info);
                        _teamMemberDAL.addTeamMember(i == 0 ? team_home_id : team_away_id, player_id);
                    }
                    _playerMatchDAL.addPlayerMatch(match_id, player_id, true);
                }
                foreach (var player in item["substitutes"]!)
                {
                    int player_id = (int)player["player"]?["id"]!;
                    if (!_playerDAL.isExistedPlayer(player_id))
                    {
                        InfoDataMember info = new InfoDataMember
                        {
                            Id = player_id,
                            Name = (string)player["player"]?["name"]!,
                            Number = (int)player["player"]?["number"]!,
                            Position = (string)player["player"]?["pos"]!,
                            Birthday = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified),
                            Nationaly = "",
                            Age = 0,
                            Weight = "0 kg",
                            Height = "0 cm",
                            Image = "",
                        };
                        _memberDAL.addMember(info);
                        _playerDAL.addPlayer(info);
                        _teamMemberDAL.addTeamMember(i == 0 ? team_home_id : team_away_id, player_id);
                    }
                    _playerMatchDAL.addPlayerMatch(match_id, player_id, false);
                }
                i++;
            }
        }

        //Them du lieu huan luyen vien
        public async Task addInfoCoach(int coach_id)
        {
            var response_coach = await _httpClient.GetAsync($"coachs?id={coach_id}");
            response_coach.EnsureSuccessStatusCode();

            var content = await response_coach.Content.ReadAsStringAsync();
            var json = JObject.Parse(content);
            InfoDataMember info = new InfoDataMember();

            foreach (var item in json["response"]!)
            {
                info.Id = coach_id;
                info.Name = (string)item["name"]!;
                info.Birthday = (DateTime)item["birth"]?["date"]!;
                info.Nationaly = (string)item["nationality"]!;
                info.Position = "Huấn luyện viên";
                info.Age = (int)item["age"]!;
                info.Image = (string)item["photo"]!;
                _memberDAL.addMember(info);
                break;
            }
            return;
        }


        //Them du lieu cau thu
        public async Task addInfoPlayer(int player_id)
        {
            var response_coach = await _httpClient.GetAsync($"players/profiles?player={player_id}");
            response_coach.EnsureSuccessStatusCode();

            var content = await response_coach.Content.ReadAsStringAsync();
            var json = JObject.Parse(content);
            InfoDataMember info = new InfoDataMember();

            foreach (var item in json["response"]!)
            {
                info.Id = player_id;
                info.Name = (string)item["player"]?["name"]!;
                info.Birthday = (DateTime)item["player"]?["birth"]?["date"]!;
                info.Nationaly = (string)item["player"]?["nationality"]!;
                info.Position = (string)item["player"]?["position"]!;
                info.Age = (int)item["player"]?["age"]!;
                info.Image = (string)item["player"]?["photo"]!;
                info.Height = (string)item["player"]?["height"]!;
                info.Weight = (string)item["player"]?["weight"]!;
                info.Number = (int)item["player"]?["number"]!;
                _playerDAL.addPlayer(info);
                break;
            }
            return;
        }
    }
}
