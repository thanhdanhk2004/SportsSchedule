namespace SportSchedule.Model
{
    public class MatchModel
    {
        public string? MatchId {  get; set; }
        public string? Venue {  get; set; }
        public string? Time {  get; set; }
        public string? Status { get; set; }
        public string? TeamIdHome {  get; set; }
        public string? TeamIdAway { get; set; }
        public string? SeasonId { get; set; }
        public string? LeagueId {  get; set; }
        public TeamModel? TeamHome { get; set; }
        public TeamModel? TeamAway {  get; set; }
        public SeasonModel? Season { get; set; }
        public LeagueModel? League { get; set; }
        public List<MatchStatictisModel>? MatchStatictis { get; set; }
        public List<PeriodModel>? Periods { get; set; }
        public List<GuessModel>? Guess { get; set; }
    }
}
