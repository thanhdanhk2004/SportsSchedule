namespace SportSchedule.Model
{
    public class PeriodModel
    {
        public string? PeriodId {  get; set; }
        public string? Name {  get; set; }
        public DateTime? Time { get; set; }
        public string? MatchId {  get; set; }
        public MatchModel? Match { get; set; }
        public List<CardModel>? Cards { get; set; }
        public List<GoalModel>? Goals { get; set; }
    }
}
