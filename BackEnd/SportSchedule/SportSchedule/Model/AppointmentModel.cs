namespace SportSchedule.Model
{
    public class AppointmentModel
    {
        public int? AppointmentId { get; set; }
        public int? UserId {  get; set; }
        public int? MatchId { get; set; }
        public bool? Status { get; set; }
        public DateTime? DateSend { get; set; }
        public UserModel? User { get; set; }
        public MatchModel? Match { get; set; }
    }
}
