using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentOrganizer.BusinessLayer.Models
{
    public class MatchModel
    {
        public int MatchNumber { get; set; }
        
        public List<IParticipant> Participants { get; set; }

        private bool _matchResolved;

        private int _numberParticipantsInMatch;

        public void MatchResolve()
        {

        }

        public bool GetMatchResolved()
        {
            return _matchResolved;
        }
        
    }
}
