namespace SportSchedule.DataTranserferObject.Award
{
    public class AwardDTOFEAdmin
    {
        public int? GuessId {  get; set; }
        public int? UserId { get; set; }
        public string? Email {  get; set; }
        public string? NameHome {  get; set; }
        public string? NameAway { get; set; }
        public int? ScoreHome {  get; set; }
        public int? ScoreAway { get; set; }
        public int? ScorePredictHome { get; set; }
        public int? ScorePredictAway { get; set; }
        
    }
}
