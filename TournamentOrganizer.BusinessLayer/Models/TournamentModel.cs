using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TournamentOrganizer.BusinessLayer.Models
{
    public class TournamentModel : INotifyPropertyChanged
    {

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

        public TournamentModel(int numberParticipantsInMatch = 2)
        {
            NumberParticipantsInMatch = numberParticipantsInMatch;
        }

        public GameModel Game
        {
            get { return _game; }
            set
            {
                _game = value;
                OnPropertyChanged(nameof(Game));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public List<ParticipantTournamentResult> ParticipantsResults { get; set; }

        public List<IParticipant> Participants { get; set; }
        public List<RoundModel> Rounds { get; private set; }
        public int NumberParticipantsInMatch { get; private set; }//2

        public int NumberRounds { get; set; }
        public void GetNumberRounds()
        {
            NumberRounds = (int)Math.Log(Participants.Count, NumberParticipantsInMatch);
        }

        public void CreateRound()
        {
            RoundModel round = new RoundModel(Participants, NumberParticipantsInMatch);
            Rounds.Add(round);
        }
    }
}
