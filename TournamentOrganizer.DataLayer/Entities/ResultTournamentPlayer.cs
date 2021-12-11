using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentOrganizer.DataLayer.Entities
{
    public class ResultTournamentPlayer
    {
        public int Id {get; set;}
        public int PlayerId { get; set; }
        public int Result { get; set; }
        public int NumberRound { get; set; }
        public int NumberGame { get; set; }
        public int TournamentId { get; set; }
    }
}
