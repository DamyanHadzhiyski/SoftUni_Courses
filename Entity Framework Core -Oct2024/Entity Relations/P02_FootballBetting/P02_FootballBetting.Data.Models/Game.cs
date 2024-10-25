using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace P02_FootballBetting.Data.Models
{
    public class Game
    {
        public int GameId { get; set; }

        public int HomeTeamId { get; set; }
        [ForeignKey(nameof(HomeTeamId))]
        public Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }
        [ForeignKey(nameof(AwayTeamId))]
        public Team AwayTeam { get; set; }

        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }
        public DateTime DateTime { get; set; }
        public decimal HomeTeamBetRate { get; set; }
        public decimal AwayTeamBetRate { get; set; }
        public decimal DrawBetRate { get; set; }
        public string Result { get; set; }

        public ICollection<Bet> Bets { get; set; }
        public ICollection<PlayerStatistic> PlayersStatistics { get; set; }

    }
}