namespace SportSchedule.DataTranserferObject.Goal
{
    public class GoalDTO
    {
        public string? GoalType {  get; set; }
        public int? PlayerId { get; set;}
        public int? MatchId { get; set;}
        public int? TeamId { get; set; }
        public int GoalTime {  get; set; }
    }
}
