namespace SportSchedule.Model
{
    public class MessageModel
    {
        public int? MessageId {  get; set; }
        public string? Content {  get; set; }
        public string? Type {  get; set; }
        public string? Image {  get; set; }
        public DateTime? SendTime { get; set; } = DateTime.UtcNow;
        public int? UserIdSend {  get; set; }
        public int? UserIdRevice { get; set; }

        public UserModel? UserSend {  get; set; }
        public UserModel? UserRevice {  get; set; }

    }
}
