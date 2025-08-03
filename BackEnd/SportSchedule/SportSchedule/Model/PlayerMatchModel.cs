namespace SportSchedule.Model
{
    public class PlayerMatchModel
    {
        public int? MatchId { get; set; }
        public int? PlayerId { get; set; }
        public bool Status { get; set; }
        public PlayerModel Player { get; set; }
        public MatchModel Match { get; set; }
    }
}
