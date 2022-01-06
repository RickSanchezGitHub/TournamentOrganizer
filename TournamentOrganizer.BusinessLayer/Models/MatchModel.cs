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
        public MatchModel()
        {
            Participants = new();
        }
        public int MatchNumber { get; set; }
        
        public ObservableCollection<IParticipant> Participants { get; set; }

        public bool MatchResolved { get; set; }

        //private int _numberParticipantsInMatch;

        public void ResolveWinner(TournamentModel tournament, IParticipant participant)
        {
            //ObservableCollection<ParticipantTournamentResult> tournamentParticipants = tournament.ParticipantsResults;
            //var winner = tournamentParticipants.First(item => item.Participant == participant);
            int? roundNumber = tournament.GetRoundByMatch(this).RoundNumber;
            ResultTournamentPlayerModel winner = new(); 
            winner.NumberMatch = MatchNumber;
            winner.Player = (PlayerModel)participant;
            winner.Tournament = tournament;
            winner.NumberRound = roundNumber;
            winner.Result = 2;
            tournament.ParticipantsResultsInMatchs.Add(winner);
            MatchResolved = true;
        }

        public void ResolveDraw(TournamentModel tournament, IParticipant participant)
        {
            // var draw = tournament.ParticipantsResults.First(item => item.Participant == participant);
            int? roundNumber = tournament.GetRoundByMatch(this).RoundNumber;
            ResultTournamentPlayerModel draw = new();
            draw.NumberMatch = MatchNumber;
            draw.Player = (PlayerModel)participant;
            draw.Tournament = tournament;
            draw.NumberRound = roundNumber;
            draw.Result = 1;
            tournament.ParticipantsResultsInMatchs.Add(draw);
            MatchResolved = true;
        }

        
    }
}
