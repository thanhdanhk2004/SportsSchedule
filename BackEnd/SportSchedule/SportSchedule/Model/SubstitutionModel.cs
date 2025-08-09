namespace SportSchedule.Model
{
    public class SubstitutionModel
    {
        public int SubId {  get; set; }
        public int Time {  get; set; }
        public int? MatchId { get; set; }
        public int? PlayerInId {  get; set; }
        public int? PlayerOutId { get; set; }
        public MatchModel Match {  get; set; }
        public PlayerModel PlayerIn {  get; set; }
        public PlayerModel PlayerOut { get; set; }
    }
}
