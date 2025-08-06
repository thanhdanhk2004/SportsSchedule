namespace SportSchedule.Model
{
    public class MatchModel
    {
        public int? MatchId {  get; set; }
        public string? Venue {  get; set; }
        public DateTime? Time {  get; set; }
        public string? Round { get; set; }
        public int? TeamIdHome {  get; set; }
        public int? TeamIdAway { get; set; }
        public int? SeasonId { get; set; }
        public int? LeagueId {  get; set; }
        public TeamModel? TeamHome { get; set; }
        public TeamModel? TeamAway {  get; set; }
        public SeasonModel? Season { get; set; }
        public LeagueModel? League { get; set; }
        public List<MatchStatictisModel>? MatchStatictis { get; set; }
        public List<PeriodModel>? Periods { get; set; }
        public List<GuessModel>? Guess { get; set; }
        public List<PlayerMatchModel>? PlayerMatches { get; set; }
        public List<CardModel>? Cards { get; set; }
        public List<GoalModel>? Goals { get; set; }


    }
}
