namespace SportSchedule.Model
{
    public class GoalModel
    {
        public int? GoalId {  get; set; }
        public int? GoalTime { get; set; }
        public string? GoalType {  get; set; }
        public int? PlayerId {  get; set; }
        public int? TeamId {  get; set; }
        public int? MatchId {  get; set; }
        public PlayerModel? Player { get; set; }
        public TeamModel? Team { get; set; }
        public MatchModel? Match { get; set; }

    }
}
