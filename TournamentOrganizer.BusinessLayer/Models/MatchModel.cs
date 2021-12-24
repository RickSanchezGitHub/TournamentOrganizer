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
        public List<ParticipantTournamentResult> Participants { get; set; }
        private bool _matchResolved;

        public void ResolveMatch()
        {
            foreach (var item in Participants)
            {
                if (item.Score == null)
                {
                    _matchResolved = false;
                    return;
                }
            }
            _matchResolved = true;
        }
    }
}
