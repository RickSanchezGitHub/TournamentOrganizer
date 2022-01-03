using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentOrganizer.BusinessLayer.Models
{
    public class MatchModel
    {
        public int MatchNumber { get; set; }
        
        public ObservableCollection<PlayerModel> Participants { get; set; }

        public bool MatchResolved { get; private set; }

        private int _numberParticipantsInMatch;

        public void ResolveWinner(List<ParticipantTournamentResult> tournamentParticipants, IParticipant participant)
        {
            var winner = tournamentParticipants.Find(item => item.Participant == participant);
            MatchResolved = true;
            winner.Score+=2;
        }

        public void ResolveDraw(List<ParticipantTournamentResult> tournamentParticipants, IParticipant participant)
        {
            var draw = tournamentParticipants.Find(item => item.Participant == participant);
            MatchResolved = true;
            draw.Score += 1;
        }

        
    }
}
