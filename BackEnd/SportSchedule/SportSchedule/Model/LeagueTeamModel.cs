namespace SportSchedule.Model
{
    public class LeagueTeamModel
    {
        public string? LeagueId {  get; set; }
        public string? TeamId {  get; set; }
        public LeagueModel? League { get; set; }
        public TeamModel? Team { get; set; }
    }
}
