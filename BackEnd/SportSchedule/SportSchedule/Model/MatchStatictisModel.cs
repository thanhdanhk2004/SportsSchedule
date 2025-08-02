namespace SportSchedule.Model
{
    public class MatchStatictisModel
    {
        public int? MatchStatictisId {  get; set; }
        public int? Score {  get; set; }
        public string? Possession { get; set; }
        public int? ShortsOnTaget {  get; set; }
        public int? Corners {  get; set; }
        public int? YellowCard { get; set; }
        public int? RedCard { get; set; }
        public int? TeamId {  get; set; }
        public int? MatchId {  get; set; }
        public TeamModel? Team { get; set; }
        public MatchModel? Match { get; set; }
    }
}
