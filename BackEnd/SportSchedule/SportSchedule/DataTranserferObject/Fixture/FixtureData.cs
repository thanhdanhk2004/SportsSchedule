namespace SportSchedule.DataTranserferObject.Fixture
{
    public class FixtureData
    {
        public int? LeagueId {  get; set; }
        public int? FixtureId { get; set; }
        public string? LeagueName { get; set; }
        public string? Logo { get; set; }
        public string? Round { get; set; }
        public string? Season { get; set; }
        public DateTime? Date { get; set; }
        public string? Venue { get; set; }
        public int? HomeId { get; set; }
        public string? HomeLogo { get; set; }
        public string? HomeName {  get; set; }
        public string? AwayLogo { get; set; }
        public int? AwayId { get; set; }
        public string? AwayName {  get; set; }
        public int? GoalHome { get; set; } = 0;
        public int? GoalAway { get; set; } = 0;
    }
}
