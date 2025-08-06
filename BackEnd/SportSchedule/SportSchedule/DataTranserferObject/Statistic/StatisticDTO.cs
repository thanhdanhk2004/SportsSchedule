using SportSchedule.DataTranserferObject.Card;
using SportSchedule.DataTranserferObject.Goal;

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
            public StatisticTeam StatisticTeamHome { get; set; }
            public StatisticTeam StatisticTeamAway { get; set; }    
            public List<PlayerDTO> PlayerHome { get; set; }
            public List<PlayerDTO> PlayerAway { get; set; }
            public List<CardDTOFE>? CardsHome { get; set; }
            public List<CardDTOFE>? CardsAway { get; set; }
            public List<GoalDTOFE>? GoalHome { get; set; }
            public List<GoalDTOFE>? GoalAway { get; set; }
        }
        public class StatisticTeam
        {
            public string? Processing { get; set; }
            public int? ShortOnGoal { get; set; }
            public int? Corners { get; set; }
            public int? YellowCards { get; set; }
            public int? RedCare { get; set; }
            public int? TeamId {  get; set; }
        }

        public class PlayerDTO
        {
            public int? Id { get; set; }
            public string? Name { get; set; }
            public bool? Status { get; set; } 
            public string? Position {  get; set; }
        }
}
