namespace SportSchedule.Model
{
    public class PlayerModel:MemberModel
    {
        public string? Height { get; set; }
        public string? Weight { get; set; }
        public bool? status { get; set; }
        public int Number {  get; set; }
        public List<GoalModel>? Goals { get; set; }
        public List<PlayerMatchModel>? PlayerMatches { get; set; }
    }
}
