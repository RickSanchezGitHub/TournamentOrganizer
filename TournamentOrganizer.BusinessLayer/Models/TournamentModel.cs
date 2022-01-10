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
    public class TournamentModel : INotifyPropertyChanged
    {
        #region NikitaSergeevich
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private DateTime? _startDate;
        public DateTime? StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        private DateTime? _closeDate;
        public DateTime? CloseDate
        {
            get { return _closeDate; }
            set
            {
                _closeDate = value;
                OnPropertyChanged(nameof(CloseDate));
            }
        }

        private GameModel _game;
        public GameModel Game
        {
            get { return _game; }
            set
            {
                _game = value;
                OnPropertyChanged(nameof(Game));
            }
        }

        private bool _onlyForTeams;

        public bool OnlyForTeams
        {
            get { return _onlyForTeams; }
            set
            {
                _onlyForTeams = value;
                OnPropertyChanged(nameof(OnlyForTeams));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        #endregion

        public TournamentModel()
        {
            Rounds = new ObservableCollection<RoundModel>();
            Participants = new();
            ParticipantsResults = new();
            ClosedTournament = false; //нахуй надо?
            StartedTournament = false;//нахуй надо?
            ParticipantsResultsInMatchs = new();
        }

        public bool ClosedTournament { get; private set; }//нахуй надо?
        public bool StartedTournament { get; private set; }//нахуй надо?
        public ObservableCollection<ParticipantTournamentResult> ParticipantsResults { get; set; }

        public ObservableCollection<IResultTournamentParticipantModel> ParticipantsResultsInMatchs { get; set; }
        public ObservableCollection<IParticipant> Participants { get; set; }
        public ObservableCollection<RoundModel> Rounds { get; private set; }

        public int NumberRounds { get; set; }
        public void SetNumberRounds()
        {
            NumberRounds = (int)Math.Log(Participants.Count, 2);
        }

        public bool CreateRound()
        {
            bool lastRoundIsResolved = Rounds.Count == 0 || Rounds.Last<RoundModel>().CheckMatchesOnResolved();
            if (lastRoundIsResolved)
            {
                int numberRound = Rounds.Count + 1;
                RoundModel newRound = new RoundModel { RoundNumber = numberRound };
                newRound.DistributeParticipants(this);
                Rounds.Add(newRound);
                if (Rounds.Count >= NumberRounds)
                {
                    CloseTournament();
                }
                
                return true;
            }
            return false;
        }

        public ObservableCollection<ObservableCollection<IParticipant>> GetAllPlayerPairsInTournament()
        {
            ObservableCollection<ObservableCollection<IParticipant>> playerPairs = new();
            for (int i = 0; i < Rounds.Count; i++)
            {
                foreach (var item in Rounds[i].GetAllParticipantPairsInMatchs())
                {
                    playerPairs.Add(item);
                }
            }
            return playerPairs;
        }

        public void CloseTournament()
        {
            ClosedTournament = true;
        }

        public void StartTournament()
        {
            StartedTournament = true;
            SetNumberRounds();
        }

        public RoundModel GetRoundByMatch(MatchModel match)
        {
            for (int i = 0; i < Rounds.Count; i++)
            {
                if (Rounds[i].Matchs.Contains(match))
                {
                    return Rounds[i];
                }
            }
            return null;
        }
    }
}
