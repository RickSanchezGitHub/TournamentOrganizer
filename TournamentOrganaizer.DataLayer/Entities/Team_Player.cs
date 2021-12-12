using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentOrganizer.DataLayer.Entities
{
    public class Team_Player
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int PlayerId { get; set; }

    }
}
