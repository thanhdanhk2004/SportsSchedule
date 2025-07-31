namespace SportSchedule.DataTranserferObject.Fixture
{
    public class FixtureDataFrontend
    {
        public string? LeagueName {  get; set; }
        public int? MatchId { get; set; }
        public string? NameHome {  get; set; }
        public string? NameAway {  get; set; }
        public string? Time {  get; set; }
        public string? LogoHome {  get; set; }
        public string? LogoAway {  get; set; }
        
        public List<int>? Scores { get; set; } = null;

    }
}
