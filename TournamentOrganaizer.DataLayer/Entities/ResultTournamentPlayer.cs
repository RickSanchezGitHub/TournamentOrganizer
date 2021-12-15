using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganaizer.DataLayer.Entities;

namespace TournamentOrganizer.DataLayer.Entities
{
    public class ResultTournamentPlayer
    {
        public int Id { get; set; }
        public Player Player { get; set; }
        public int Result { get; set; }
        public int NumberRound { get; set; }
        public int NumberMatch { get; set; }
        public Tournament Tournament { get; set; }
    }
}
