using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentOrganaizer.DataLayer.Entities
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CloseDate { get; set; }
        public Game Game { get; set; }
        public bool OnlyForTeams { get; set; }
    }
}
