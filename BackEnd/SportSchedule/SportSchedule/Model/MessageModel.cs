namespace SportSchedule.Model
{
    public class MessageModel
    {
        public string? MessageId {  get; set; }
        public string? Content {  get; set; }
        public string? Type {  get; set; }
        public string? Image {  get; set; }
        public DateTime? SendTime { get; set; } = DateTime.UtcNow;
        public string? UserIdSend {  get; set; }
        public string? UserIdRevice { get; set; }

        public UserModel? UserSend {  get; set; }
        public UserModel? UserRevice {  get; set; }

    }
}
