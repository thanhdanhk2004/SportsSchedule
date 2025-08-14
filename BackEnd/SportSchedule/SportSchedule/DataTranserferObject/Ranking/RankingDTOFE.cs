namespace SportSchedule.DataTranserferObject.Ranking
{
    public class RankingDTOFE
    {
        public int? TeamId { get; set; }
        public string? TeamName { get; set; }
        public string? Logo {  get; set; }
        public int? Played { get; set; }
        public int? Win {  get; set; }
        public int? Draw {  get; set; }
        public int? Loss { get; set; }
        public int? Point { get; set; }
        public int? Difference {  get; set; }
    }
}
