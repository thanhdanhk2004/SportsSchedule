namespace SportSchedule.Model
{
    public class AwardModel
    {
        public string? AwardId {  get; set; }
        public string? Description { get; set; }
        public string? Gift {  get; set; }
        public string? GuessId {  get; set; }
        public GuessModel? Guess { get; set; }
    }
}
