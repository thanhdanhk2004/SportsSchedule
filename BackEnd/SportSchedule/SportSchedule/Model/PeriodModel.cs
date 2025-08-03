namespace SportSchedule.Model
{
    public class PeriodModel
    {
        public int? PeriodId {  get; set; }
        public string? Name {  get; set; }
        public DateTime? Time { get; set; }
        public int? GoalHome {  get; set; }
        public int? GoalAway { get; set; }
        public int? MatchId {  get; set; }
        public MatchModel? Match { get; set; }
        public List<CardModel>? Cards { get; set; }
        public List<GoalModel>? Goals { get; set; }
    }
}
