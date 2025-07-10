namespace SportSchedule.Model
{
    public class GoalModel
    {
        public string? GoalId {  get; set; }
        public DateTime? GoalDate { get; set; } = DateTime.UtcNow;
        public string? GoalType {  get; set; }
        public string? PlayerId {  get; set; }
        public string? TeamId {  get; set; }
        public string? PeriodId {  get; set; }
        public PlayerModel? Player { get; set; }
        public TeamModel? Team { get; set; }
        public PeriodModel? Period { get; set; }

    }
}
