using Newtonsoft.Json.Linq;
using SportSchedule.Context;
using SportSchedule.DataAccess;
using SportSchedule.DataModel;
using SportSchedule.DataTranserferObject.Player;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace SportSchedule.Services.Member
{
    public class MemberService : IMemberService
    {
        private readonly HttpClient _httpClient;
        private readonly MemberDAL _memberDAL;
        private readonly PlayerDAL _playerDAL;
        private readonly PlayerMatchDAL _playerMatchDAL;
        private readonly TeamMemberDAL _teamMemberDAL;
        private readonly IMemoryCache _cache;
        private readonly MatchStatisticDAL _matchStatisticDAL;

        public MemberService(ContextDB context, IHttpClientFactory httpClient, MemberDAL member, PlayerDAL playerDAL, PlayerMatchDAL playerMatchDAL, TeamMemberDAL teamMemberDAL, IMemoryCache cache, MatchStatisticDAL matchStatisticDAL)
        {
            _httpClient = httpClient.CreateClient("FootballAPI");
            _memberDAL = member;
            _playerDAL = playerDAL;
            _playerMatchDAL = playerMatchDAL;
            _teamMemberDAL = teamMemberDAL;
            _cache = cache;
            _matchStatisticDAL = matchStatisticDAL;
        }
        public async Task getMemberService(int fixture_id, int team_home_id, int team_away_id, int match_id)
        {
            var response_lineup = await _httpClient.GetAsync($"fixtures/lineups?fixture={fixture_id}");
            response_lineup.EnsureSuccessStatusCode();

            var content = await response_lineup.Content.ReadAsStringAsync();
            var json = JObject.Parse(content);

            int i = 0;
            foreach(var item in json["response"]!)
            {
                string line_up = (string)item["formation"]!;
                if(i == 0)
                {
                    _matchStatisticDAL.updateLineUp(match_id, team_home_id, line_up);
                }
                else
                {
                    _matchStatisticDAL.updateLineUp(match_id, team_away_id, line_up);
                }

                int coach_id = (int)item["coach"]?["id"]!;
                //Kiem tra co ton tai HLV hay chua
                if (!_memberDAL.isExistedMember(coach_id))
                {
                    await this.addInfoCoach(coach_id);
                    _teamMemberDAL.addTeamMember(i == 0 ? team_home_id : team_away_id, coach_id);
                }

                foreach (var player in item["startXI"]!)
                {
                    int player_id = (int)player["player"]?["id"]!;
                    //Kiem tra co ton tai cau thu hay chua neu chua thi moi them
                    if (!_playerDAL.isExistedPlayer(player_id))
                    {
                        InfoDataMember info = new InfoDataMember
                        {
                            Id = player_id,
                            Name = (string?)player["player"]?["name"] ?? "",
                            Number = (int?)player["player"]?["number"]?? 0,
                            Position = (string?)player["player"]?["pos"] ?? "M",
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
                    int player_id = player["player"]?["id"]?.Value<int?>()??0;
                    if (player_id == 0)
                        continue;
                    if (!_playerDAL.isExistedPlayer(player_id))
                    {
                        InfoDataMember info = new InfoDataMember
                        {
                            Id = player_id,
                            Name = (string?)player["player"]?["name"] ?? "",
                            Number = (int?)player["player"]?["number"] ?? 0,
                            Position = (string?)player["player"]?["pos"] ?? "",
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
                info.Name = (string?)item["name"] ?? "";
                info.Birthday = (DateTime?)item["birth"]?["date"] ?? DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified);
                info.Nationaly = (string?)item["nationality"] ?? "";
                info.Position = "Huấn luyện viên";
                info.Age =(int?) item["age"] ?? 0;
                info.Image = (string?)item["photo"] ?? "";
                _memberDAL.addMember(info);
                break;
            }
            return;
        }


        //Them du lieu cau thu
        public async Task<InfoDataMember> getDataPlayer(int player_id)
        {
            var response_coach = await _httpClient.GetAsync($"players/profiles?player={player_id}");
            response_coach.EnsureSuccessStatusCode();

            var content = await response_coach.Content.ReadAsStringAsync();
            var json = JObject.Parse(content);
            InfoDataMember info = new InfoDataMember();

            foreach (var item in json["response"]!)
            {
                info.Id = player_id;
                info.Name = (string?)item["player"]?["name"] ?? "";
                info.Birthday = (DateTime?)item["player"]?["birth"]?["date"] ?? DateTime.MinValue;
                info.Nationaly = (string?)item["player"]?["nationality"] ?? "";
                info.Position = (string?)item["player"]?["position"] ?? "";
                info.Age = (int?)item["player"]?["age"] ?? 0;
                info.Image = (string?)item["player"]?["photo"] ?? "";
                info.Height = (string?)item["player"]?["height"] ?? "";
                info.Weight = (string?)item["player"]?["weight"] ?? "";
                info.Number = (int?)item["player"]?["number"] ?? 0;
                break;
            }
            return info;
        }
        
        //Lay thong tin cau thu (truơng hop chua co thoong tin thi phai cap nhat)
        public async Task<PlayerInfoDTOFE> getPlayerInfo(int player_id)
        {
            string weight = _playerDAL.getWeightPlayer(player_id);
            if(weight == "0 kg")
            {
                InfoDataMember info_player = await this.getDataPlayer(player_id);
                _playerDAL.updateInfoPlayer(player_id, info_player);
            }
            string key_cache = $"info_player_{player_id}";
            if (_cache.TryGetValue(key_cache, out PlayerInfoDTOFE player))
                return player;
            var data = _playerDAL.getPlayer(player_id) ;
            if (data != null)
                _cache.Set(key_cache, data, TimeSpan.FromMinutes(30));
            return data;
        }
    }
}
