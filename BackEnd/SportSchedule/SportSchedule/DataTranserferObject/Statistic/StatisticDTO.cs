using SportSchedule.DataTranserferObject.Card;
using SportSchedule.DataTranserferObject.Goal;
using SportSchedule.DataTranserferObject.Player;
using SportSchedule.DataTranserferObject.Substitution;

namespace SportSchedule.DataTranserferObject.Statistic
{
    public class StatisticDTO
    {
        public string? LeagueName { get; set; }
        public string? NameHome { get; set; }
        public string? NameAway { get; set; }
        public string? Time { get; set; }
        public string? LogoHome { get; set; }
        public string? LogoAway { get; set; }
        public int? GoalHomeFirst { get; set; }
        public int? GoalHomeFullTime { get; set; }
        public int? GoalAwayFirst { get; set; }
        public int? GoalAwayFullTime { get; set; }
        public StatisticDTOFE StatisticTeamHome { get; set; }
        public StatisticDTOFE StatisticTeamAway { get; set; }
        public List<PlayerDTOFE> PlayerHome { get; set; }
        public List<PlayerDTOFE> PlayerAway { get; set; }
        public List<CardDTOFE>? CardsHome { get; set; }
        public List<CardDTOFE>? CardsAway { get; set; }
        public List<GoalDTOFE>? GoalHome { get; set; }
        public List<GoalDTOFE>? GoalAway { get; set; }
        public List<SubstitutionDTOFE>? SubHome { get; set; }
        public List<SubstitutionDTOFE>? SubAway { get; set; }
    }  
}
