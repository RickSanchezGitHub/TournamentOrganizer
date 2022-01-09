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
    public class MatchModel: INotifyPropertyChanged
    {
        public MatchModel()
        {
            Participants = new();
            PlayersResults = new();
            TeamsResults = new();
        }
        public int MatchNumber { get; set; }

        public ObservableCollection<IParticipant> Participants { get; set; }

        public ObservableCollection<ResultTournamentPlayerModel> PlayersResults { get; set; }
        public ObservableCollection<ResultTournamentTeamModel> TeamsResults { get; set; }

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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public int ResolveWinner(TournamentModel tournament, IParticipant participant)
        {
            int roundNumber = tournament.GetRoundByMatch(this).RoundNumber;
            //var winner = tournament.ParticipantsResults.First(item => item.Participant.Equals(participant));
            if (tournament.OnlyForTeams)
            {
                var resultWinner = TeamsResults.First(item => item.Team.Equals(participant)).Result = 2;
                var resultLooser = TeamsResults.First(item => !item.Team.Equals(participant)).Result = 0;
            }
            else
            {
                var resultWinner = PlayersResults.First(item => item.Player.Equals(participant)).Result = 2;
                var resultLooser = PlayersResults.First(item => !item.Player.Equals(participant)).Result = 0;
            }
            //winner.Score += 2;
            MatchResolved = true;
            return roundNumber;
        }

        public int ResolveDraw(TournamentModel tournament, IParticipant participant)
        {

            //var draw = tournament.ParticipantsResults.First(item => item.Participant.Equals(participant));
            int roundNumber = tournament.GetRoundByMatch(this).RoundNumber;
           
            if(tournament.OnlyForTeams)
                TeamsResults.First(item => item.Team.Equals(participant)).Result = 1;
            else
                PlayersResults.First(item => item.Player.Equals(participant)).Result = 1;
            
            //draw.Score += 1;
            MatchResolved = true;
            return roundNumber;
        }


    }
}
