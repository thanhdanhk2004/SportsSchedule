using Newtonsoft.Json.Linq;
using SportSchedule.DataAccess;
using SportSchedule.DataTranserferObject.Fixture;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace SportSchedule.Services.Statistic
{
    public class StatisticService : IStatisticService
    {
        private MatchStatisticDAL _matchStatictis;
        private readonly HttpClient _httpClient;
        private readonly PeriodDAL _periodDAL;

        public StatisticService(MatchStatisticDAL matchStatictis, IHttpClientFactory httpClient, PeriodDAL periodDAL)
        {
            _matchStatictis = matchStatictis;
            _httpClient = httpClient.CreateClient("FootballAPI");
            _periodDAL = periodDAL;
        }

        //Lay thong so cua tran dau
        public async Task<int> getStatisticFixture(string? name_home, string? name_away, DateTime? time, string? league_name, int? home_id, int? away_id, int? match_id, string? Round)
        {
            var response_fixtures = await _httpClient.GetAsync($"fixtures?date={time.Value.ToString("yyyy-MM-dd")}&round={Round}");
            response_fixtures.EnsureSuccessStatusCode();

            var content = await response_fixtures.Content.ReadAsStringAsync();
            var json = JObject.Parse(content);

            int fixture_id = 0;

            foreach (var item in json["response"]!)
            {
                string? round = (string?)item["league"]?["round"];
                string? leagueName = (string?)item["league"]?["name"];
                DateTime? date = (DateTime?)item["fixture"]?["date"];

                if (round == Round && leagueName == league_name)
                {
                    fixture_id = (int)item["fixture"]!["id"]!;
                    int team_home_id =(int) item["teams"]!["home"]!["id"]!;
                    int team_away_id =(int) item["teams"]!["away"]!["id"]!;
                    FixtureStatisticData fixture_statistic_home = new FixtureStatisticData();
                    fixture_statistic_home.TeamId = home_id;
                    fixture_statistic_home.FixtureId = match_id;
                    fixture_statistic_home.Score = item["score"]?["fulltime"]?["home"]?.Value<int?>() ?? 0;

                    FixtureStatisticData fixture_statistic_away = new FixtureStatisticData();
                    fixture_statistic_away.TeamId = home_id;
                    fixture_statistic_away.FixtureId = match_id;
                    fixture_statistic_away.Score = item["score"]?["fulltime"]?["away"]?.Value<int?>() ?? 0;

                    //Lay thong so cua tung doi
                    var response_statistics = await _httpClient.GetAsync($"fixtures/statistics?fixture={fixture_id}");
                    response_statistics.EnsureSuccessStatusCode();

                    var content_statistics = await response_statistics.Content.ReadAsStringAsync();
                    var json_statistics = JObject.Parse(content_statistics);

                    JObject? homeStats = null;
                    JObject? awayStats = null;
                    foreach (var json_statistic in json_statistics["response"]!)
                    {
                        var teamId = (int)json_statistic["team"]!["id"]!;
                        if (teamId == team_home_id)
                           homeStats = (JObject)json_statistic;
                        else if (teamId == team_away_id) 
                           awayStats = (JObject)json_statistic;
                    }
                    fixture_statistic_home.Possession = getStatsValue((JArray)homeStats?["statistics"]!, "Ball Possession");
                    fixture_statistic_home.ShotsOnGoal = int.Parse(getStatsValue((JArray)homeStats?["statistics"]!, "Shots on Goal")!);
                    fixture_statistic_home.Corner = int.TryParse((getStatsValue((JArray)homeStats?["statistics"]!, "Corner Kicks")), out int result_corner_home) ? result_corner_home : 0;
                    fixture_statistic_home.YellowCard = int.TryParse((getStatsValue((JArray)homeStats?["statistics"]!, "Yellow Cards")), out int result_yellow_card_home) ? result_yellow_card_home : 0;
                    fixture_statistic_home.RedCard = int.TryParse((getStatsValue((JArray)homeStats?["statistics"]!, "Red Cards")), out int result_red_card_home) ? result_red_card_home : 0;

                    fixture_statistic_away.Possession = getStatsValue((JArray)awayStats?["statistics"]!, "Ball Possession");
                    fixture_statistic_away.ShotsOnGoal = int.Parse(getStatsValue((JArray)awayStats?["statistics"]!, "Shots on Goal")!);
                    fixture_statistic_away.Corner = int.TryParse((getStatsValue((JArray)awayStats?["statistics"]!, "Corner Kicks")), out int result_corner_away) ? result_corner_away : 0;
                    fixture_statistic_away.YellowCard = int.TryParse((getStatsValue((JArray)awayStats?["statistics"]!, "Yellow Cards")), out int result_yellow_card_away) ? result_yellow_card_away : 0;
                    fixture_statistic_away.RedCard = int.TryParse((getStatsValue((JArray)awayStats?["statistics"]!, "Red Cards")), out int result_red_card_away) ? result_red_card_away : 0;

                    _matchStatictis.addMatchStatistic(fixture_statistic_home, home_id, match_id);
                    _matchStatictis.addMatchStatistic(fixture_statistic_away, away_id, match_id);
                    PeriodData periodFirst = getPeriod(item, "first");
                    PeriodData periodSecond = getPeriod(item, "second");
                    _periodDAL.addPeriod(periodFirst, match_id);
                    _periodDAL.addPeriod(periodSecond, match_id);

                    break;
                }
                 
            }
            return fixture_id;
        }

        //Ham lay thong so
        public string? getStatsValue(JArray stats, string type)
        {
            var stat = stats.FirstOrDefault(s => s["type"]?.ToString() == type);
            return stat?["value"]?.ToString();
        }

        //Ham lay period cho mot doi
        public PeriodData getPeriod(JToken json, string name)
        {
            PeriodData period = new PeriodData();
            period.Time = (long)json["fixture"]?["periods"]?[name]!;
            period.Name = name;
            period.GoalHome = name == "first" ? (int)json["score"]?["halftime"]?["home"]! : 0;
            period.GoalAway = name == "first" ? (int)json["score"]?["halftime"]!["away"]! : 0;
            return period;
        }

        ////Lay du lieu cau thu
        //public 
    }
}
