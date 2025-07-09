namespace SportSchedule.Model
{
    public class SeasonModel
    {
        public string? SeasonId {  get; set; }
        public string? SeasonYear {  get; set; }
        public List<LeagueModel>? Leagues { get; set; }
        public List<MatchModel>? Matchs { get; set; }
    }
}
