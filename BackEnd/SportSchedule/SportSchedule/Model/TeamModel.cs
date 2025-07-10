namespace SportSchedule.Model
{
    public enum TeamType
    {
        Club = 1,
        National = 2
    }
    public class TeamModel
    {
        public string? TeamId { get; set; }
        public string? Name {  get; set; }
        public string? Country { get; set; } 
        public string? Logo { get; set; }
        public string? NameHome { get; set; }
        public TeamType? TeamType { get; set; }
        public List<TeamMemberModel>? TeamMembers { get; set; }
        public List<LeagueTeamModel>? LeagueTeams { get; set; }
        public List<RankingModel>? Rankings { get; set; }
        public List<MatchModel>? MatchTeamHomes { get; set; }
        public List<MatchModel>? MatchTeamAways { get; set; }
        public List<MatchStatictisModel>? MatchStatictis { get; set; }
        public List<GoalModel>? Goals { get; set; }
    }
}
