namespace SportSchedule.Model
{
    public class AwardModel
    {
        public int? AwardId {  get; set; }
        public string? Description { get; set; }
        public bool? Status { get; set; }
        public DateTime? TimeAward { get; set; }
        public int? GuessId {  get; set; }
        public GuessModel? Guess { get; set; }
    }
}
