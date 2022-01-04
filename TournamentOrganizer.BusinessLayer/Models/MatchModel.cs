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
        
        public ObservableCollection<IParticipant> Participants { get; set; }

        public bool MatchResolved { get; private set; }

        private int _numberParticipantsInMatch;

        public void ResolveWinner(TournamentModel tournament, IParticipant participant)
        {
            ObservableCollection<ParticipantTournamentResult> tournamentParticipants = tournament.ParticipantsResults;
            var winner = tournamentParticipants.First(item => item.Participant == participant);
            MatchResolved = true;
            winner.Score+=2;
        }

        public void ResolveDraw(TournamentModel tournament, IParticipant participant)
        {
            var draw = tournament.ParticipantsResults.First(item => item.Participant == participant);
            MatchResolved = true;
            draw.Score += 1;
        }

        
    }
}
