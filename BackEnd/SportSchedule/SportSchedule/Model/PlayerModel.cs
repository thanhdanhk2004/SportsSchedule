namespace SportSchedule.Model
{
    public class PlayerModel
    {
        public int PlayerId {  get; set; }
        public string? Height { get; set; }
        public string? Weight { get; set; }
        public bool? status { get; set; }
        public int Number {  get; set; }
        public MemberModel Member { get; set; }
        public List<GoalModel>? Goals { get; set; }
        public List<PlayerMatchModel>? PlayerMatches { get; set; }
        public SubstitutionModel SubstitutionIn { get; set; }
        public SubstitutionModel SubstitutionOut { get; set; }
    }
}
