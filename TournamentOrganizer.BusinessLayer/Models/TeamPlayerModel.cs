using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TournamentOrganizer.BusinessLayer.Models
{
    public class TeamPlayerModel : INotifyPropertyChanged
    {

        private int _id;
        public int Id 
        {
            get => _id;
            set 
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private int _teamId;
        public int TeamId 
        {
            get => _teamId;
            set
            {
                _teamId = value;
                OnPropertyChanged(nameof(TeamId));
            }
        }

        private int _playerId;
        public int PlayerId 
        {
            get => _playerId;
            set
            {
                _playerId = value;
                OnPropertyChanged(nameof(PlayerId));
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
