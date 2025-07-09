namespace SportSchedule.Model
{
    public class PlayerModel:MemberModel
    {
        public float? Height { get; set; }
        public float? Weight { get; set; }
        public string? value {  get; set; }
        public bool? status { get; set; }
        public List<GoalModel>? Goals { get; set; }
    }
}
