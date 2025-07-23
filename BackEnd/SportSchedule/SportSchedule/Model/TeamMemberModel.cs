namespace SportSchedule.Model
{
    public class TeamMemberModel
    {
        public int? TeamId {  get; set; }
        public int? MemberId {  get; set; }
        public TeamModel? Team { get; set; }
        public MemberModel? Member { get; set; }
    }
}
