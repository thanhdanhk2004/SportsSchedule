namespace SportSchedule.Model
{
    public class LeagueModel
    {
        public int? LeagueId {  get; set; }
        public string? Name {  get; set; }
        public string? Country {  get; set; }
        public string? Logo {  get; set; }
        public List<LeagueTeamModel>? LeagueTeams { get; set; }
        public List<RankingModel>? Rankings { get; set; }
        public List<MatchModel>? Matchs { get; set; }
        public List<LeagueSeasonModel>? LeagueSeasons { get; set; }
    }
}
