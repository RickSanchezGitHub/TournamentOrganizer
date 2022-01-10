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

        public override bool Equals(object obj)
        {
            return obj is Tournament tournament &&
                   Id == tournament.Id &&
                   Name == tournament.Name &&
                   StartDate == tournament.StartDate &&
                   CloseDate == tournament.CloseDate &&
                   EqualityComparer<Game>.Default.Equals(Game, tournament.Game) &&
                   OnlyForTeams == tournament.OnlyForTeams;
        }

    }
}
