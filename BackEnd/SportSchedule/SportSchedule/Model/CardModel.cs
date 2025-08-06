namespace SportSchedule.Model
{
    public class CardModel
    {
        public int? CardId { get; set; }
        public string? TypeCard {  get; set; }
        public int? Time {  get; set; }
        public string? Status { get; set; }
        public int? MemberId { get; set; }
        public int? MatchId {  get; set; }
        public MemberModel? Member { get; set; }
        public MatchModel? Match { get; set; }
    }
}
