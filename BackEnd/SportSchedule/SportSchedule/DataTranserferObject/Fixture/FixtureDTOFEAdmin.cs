namespace SportSchedule.DataTranserferObject.Fixture
{
    public class FixtureDTOFEAdmin
    {
        public int? MatchId { get; set; }
        public string? NameLeague {  get; set; }
        public string? TeamHome {  get; set; }
        public string? TeamAway { get; set; }
        public string? LogoHome {  get; set; }
        public string? LogoAway {  get; set; }
        public string? Time {  get; set; }
        public bool? Predict { get; set; }
        public int? TotalPage { get; set; }
    }
}
