using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    public class Color
    {
        public int ColorId { get; set; }
        public string Name { get; set; }
        [InverseProperty("PrimaryKitColor")]
        public ICollection<Team> PrimaryKitTeams { get; set;}
        [InverseProperty("SecondaryKitColor")]
        public ICollection<Team> SecondaryKitTeams { get; set;}
    }
}
