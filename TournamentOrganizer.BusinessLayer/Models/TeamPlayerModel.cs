using System.ComponentModel;
using System.Runtime.CompilerServices;

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

        public override bool Equals(object obj)
        {
            return obj is TeamPlayerModel model &&
                   Id == model.Id &&
                   TeamId == model.TeamId &&
                   PlayerId == model.PlayerId;
        }
    }
}
