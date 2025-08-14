namespace SportSchedule.Model
{
    public class SeasonModel
    {
        public int? SeasonId {  get; set; }
        public string? SeasonYear {  get; set; }
        public List<LeagueSeasonModel>? LeagueSeasons { get; set; }
        public List<MatchModel>? Matchs { get; set; }
        public List<RankingModel>? Rankings { get; set; }
    }
}
