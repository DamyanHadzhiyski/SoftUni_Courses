﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace P02_FootballBetting.Data.Models
{
    public class Player
    {
        public int PlayerId { get; set; }

        public string Name { get; set; }
        public int SquadNumber { get; set; }
        public int Assists { get; set; }
        public int TownId { get; set; }
        [ForeignKey(nameof(TownId))]
        public Town Town { get; set; }
        public int PositionId { get; set; }
        [ForeignKey(nameof(PositionId))]
        public Position Position { get; set; }
        public bool IsInjured { get; set; }
        public int TeamId { get; set; }
        [ForeignKey(nameof(TeamId))]
        public Team Team { get; set; }

        public ICollection<PlayerStatistic> PlayersStatistics { get; set; }

    }
}