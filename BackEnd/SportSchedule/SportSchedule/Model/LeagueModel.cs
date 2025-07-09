namespace SportSchedule.Model
{
    public class LeagueModel
    {
        public string? LeagueId {  get; set; }
        public string? Name {  get; set; }
        public string? Country {  get; set; }
        public string? Logo {  get; set; }
        public string? SeasonId { get; set; }
        public SeasonModel? Season { get; set; }
        public List<LeagueTeamModel>? LeagueTeams { get; set; }
        public List<RankingModel>? Rankings { get; set; }
        public List<MatchModel>? Matchs { get; set; }
    }
}
