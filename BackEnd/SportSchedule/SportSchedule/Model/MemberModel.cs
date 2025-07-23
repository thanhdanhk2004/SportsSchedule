namespace SportSchedule.Model
{
    public class MemberModel
    {
        public int? MemberId { get; set; }
        public string? Name {  get; set; }
        public DateTime? Birthday { get; set; }
        public string? Nationality {  get; set; }
        public string? Position {  get; set; }
        public string? Age {  get; set; }
        public List<TeamMemberModel>? TeamMembers{ get; set; }

    }
}
