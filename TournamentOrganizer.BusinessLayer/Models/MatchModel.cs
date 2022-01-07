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
            ParticipantsResults = new();
        }
        public int MatchNumber { get; set; }

        public ObservableCollection<IParticipant> Participants { get; set; }

        public ObservableCollection<IResultTournamentParticipantModel> ParticipantsResults { get; set; }

        public bool MatchResolved { get; set; }

        //private int _numberParticipantsInMatch;

        //ЗДЕСЬ АПДЕЙТ РЕЗУЛЬТАТА ПО ИГРОКУ РАУНДУ ТУРНИРУ
        public int ResolveWinner(TournamentModel tournament, IParticipant participant)
        {
            int roundNumber = tournament.GetRoundByMatch(this).RoundNumber;
            var winner = tournament.ParticipantsResults.First(item =>
            item.Participant.Equals(participant));

            winner.Score += 2;
            MatchResolved = true;
            return roundNumber;
        }

        public int ResolveDraw(TournamentModel tournament, IParticipant participant)
        {

            var draw = tournament.ParticipantsResults.First(item => item.Participant.Equals(participant));
            int roundNumber = tournament.GetRoundByMatch(this).RoundNumber;
            draw.Score += 1;
            MatchResolved = true;
            return roundNumber;
        }


    }
}
