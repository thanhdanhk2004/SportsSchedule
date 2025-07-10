namespace SportSchedule.DataTranserferObject
{
    public class LeagueResponse
    {
        public List<LeagueData> response { get; set; }
    }
    public class LeagueData
    {
        public League league { get; set; }
        public Country country { get; set; }
    }

    public class League
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string logo { get; set; }
    }

    public class Country
    {
        public string name { get; set; }
        public string code { get; set; }
        public string flag { get; set; }
    }
}
