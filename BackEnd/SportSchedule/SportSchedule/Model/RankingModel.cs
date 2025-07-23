
namespace SportSchedule.Model
{
    public class RankingModel
    {
        public int? RankingId {  get; set; }
        public int? Played { get; set; }
        public int? Win {  get; set; }
        public int? Draw {  get; set; }
        public int? Loss { get; set; }
        public int? GoalsFor {  get; set; }
        public int? GoalsAgainst {  get; set; }
        public int? GoalDifference {  get; set; }
        public int? Point {  get; set; }
        public int? Position { get; set; }
        public int? TeamId {  get; set; }
        public int? LeagueId {  get; set; }
        public TeamModel? Team { get; set; }
        public LeagueModel? League { get; set; }
    }
}
