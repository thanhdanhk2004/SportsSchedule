namespace SportSchedule.Model
{
    public class GoalModel
    {
        public int? GoalId {  get; set; }
        public DateTime? GoalDate { get; set; } = DateTime.UtcNow;
        public string? GoalType {  get; set; }
        public int? PlayerId {  get; set; }
        public int? TeamId {  get; set; }
        public int? PeriodId {  get; set; }
        public PlayerModel? Player { get; set; }
        public TeamModel? Team { get; set; }
        public PeriodModel? Period { get; set; }

    }
}
