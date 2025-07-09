namespace SportSchedule.Model
{
    public class MatchStatictisModel
    {
        public string? MatchStatictisId {  get; set; }
        public string? Score {  get; set; }
        public string? Possession { get; set; }
        public int? ShortsOnTaget {  get; set; }
        public int? Corners {  get; set; }
        public int? YellowCard { get; set; }
        public int? RedCard { get; set; }
        public string? TeamId {  get; set; }
        public string? MatchId {  get; set; }
        public TeamModel? Team { get; set; }
        public MatchModel? Match { get; set; }
    }
}
