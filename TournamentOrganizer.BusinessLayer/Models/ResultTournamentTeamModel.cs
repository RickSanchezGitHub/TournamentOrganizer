using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TournamentOrganizer.BusinessLayer.Models
{
    public class ResultTournamentTeamModel: INotifyPropertyChanged, IResultTournamentParticipantModel
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
        private PlayerModel _player;
        public PlayerModel Player
        {
            get { return _player; }
            set
            {
                _player = value;
                OnPropertyChanged(nameof(Player));
            }
        }

        private int? _result;
        public int? Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        private int? _numberRound;
        public int? NumberRound
        {
            get { return _numberRound; }
            set
            {
                _numberRound = value;
                OnPropertyChanged(nameof(NumberRound));
            }
        }

        private int? _numberMatch;
        public int? NumberMatch
        {
            get { return _numberMatch; }
            set
            {
                _numberMatch = value;
                OnPropertyChanged(nameof(NumberMatch));
            }
        }
        private TournamentModel _tournament;
        public TournamentModel Tournament
        {
            get { return _tournament; }
            set
            {
                _tournament = value;
                OnPropertyChanged(nameof(Tournament));
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
