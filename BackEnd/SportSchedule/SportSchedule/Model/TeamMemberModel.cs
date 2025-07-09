namespace SportSchedule.Model
{
    public class TeamMemberModel
    {
        public string? TeamId {  get; set; }
        public string? MemberId {  get; set; }
        public TeamModel? Team { get; set; }
        public MemberModel? Member { get; set; }
    }
}
