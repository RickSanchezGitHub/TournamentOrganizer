using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TournamentOrganizer.BusinessLayer.Models
{
    public class MatchModel : BaseModel
    {
        public MatchModel()
        {
            Participants = new();
            ParticipantsResults = new();
        }
        public int MatchNumber { get; set; }
        public ObservableCollection<IParticipant> Participants { get; set; }
        public ObservableCollection<IResultTournamentParticipantModel> ParticipantsResults { get; set; }


        private bool _matchResolved;
        public bool MatchResolved
        {
            get { return _matchResolved; }
            set
            {
                _matchResolved = value;
                OnPropertyChanged(nameof(MatchResolved));
            }
        }

        public int ResolveWinner(TournamentModel tournament, IResultTournamentParticipantModel participantResult)
        {
            int roundNumber = tournament.GetRoundByMatch(this).RoundNumber;

            ParticipantsResults.First(item => item.Id == participantResult.Id).Result = 2;
            ParticipantsResults.First(item => item.Id != participantResult.Id).Result = 0;
            
            MatchResolved = true;
            return roundNumber;
        }

        public int ResolveDraw(TournamentModel tournament, IResultTournamentParticipantModel participantResult)
        {
            int roundNumber = tournament.GetRoundByMatch(this).RoundNumber;

            ParticipantsResults.First(item => item.Id == participantResult.Id).Result=1;

            MatchResolved = true;
            return roundNumber;
        }


    }
}
