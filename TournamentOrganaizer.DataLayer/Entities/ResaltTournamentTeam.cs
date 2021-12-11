using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentOrganizer.DataLayer.Entities
{
   public class ResaltTournamentTeam
    {
        public int Id { get; set; }
        public Team Team { get; set; }
        public int Result { get; set; }
        public int NumberRound { get; set; }
        public int NumberMatch { get; set; }
        public int Tournament { get; set; }
    }
}
