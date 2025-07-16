namespace SportSchedule.DataTranserferObject.League
{
    public class LeagueData
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Country {  get; set; }
        public string? Logo {  get; set; }
        public List<string>? Seasons { get; set; }
    }
}
