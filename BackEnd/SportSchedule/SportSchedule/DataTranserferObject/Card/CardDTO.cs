namespace SportSchedule.DataTranserferObject.Card
{
    public class CardDTO
    {
        public string? TypeCard {  get; set; }
        public int? Time {  get; set; }
        public string? Status {  get; set; }
        public int? MatchId { get; set; }
        public int? MemberId { get; set; }
    }
}
