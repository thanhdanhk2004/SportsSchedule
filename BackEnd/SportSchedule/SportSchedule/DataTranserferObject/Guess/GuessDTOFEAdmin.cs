namespace SportSchedule.DataTranserferObject.Guess
{
    public class GuessDTOFEAdmin
    {
        public int TotalPage {  get; set; }
        public int? MatchId { get; set; }
        public string? LeagueName {  get; set; }
        public string? TeamNameHome { get; set; }
        public string? TeamNameAway { get; set; }
        public string? MatchTime { get; set; }
        public string? LogoNameHome { get; set; }
        public string? LogoNameAway { get; set; }
        public string? RepresentativeHome { get; set; }
        public string? RepresentativeAway { get; set; }
    }
}
