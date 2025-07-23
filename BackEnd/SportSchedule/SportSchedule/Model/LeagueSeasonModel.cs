namespace SportSchedule.Model
{
    public class LeagueSeasonModel
    {
        public int? LeagueId {  get; set; }
        public int? SeasonId { get; set; }
        public LeagueModel? League { get; set; }
        public SeasonModel? Season { get; set; }

    }
}
