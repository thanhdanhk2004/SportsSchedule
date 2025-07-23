namespace SportSchedule.Model
{
    public class CardModel
    {
        public int? CardId { get; set; }
        public string? TypeCard {  get; set; }
        public int? Time {  get; set; }
        public string? Status { get; set; }
        public int? PeriodId {  get; set; }
        public PeriodModel? Period { get; set; }
    }
}
