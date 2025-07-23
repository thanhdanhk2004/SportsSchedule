namespace SportSchedule.Model
{
    public class GuessModel
    {
        public int? GuessId {  get; set; }
        public DateTime? GuessTime { get; set; } = DateTime.UtcNow;
        public int? PredictHomeScore {  get; set; }
        public int? PredictAwayScore { get; set; }
        public int? MatchId {  get; set; }
        public int? UserId {  get; set; }
        public MatchModel? Match { get; set; }
        public UserModel? User { get; set; }
        public AwardModel? Award { get; set; }
    }
}
