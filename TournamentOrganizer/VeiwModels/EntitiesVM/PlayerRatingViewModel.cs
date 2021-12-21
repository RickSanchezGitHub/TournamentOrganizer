using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.BusinessLayer.Models;

namespace TournamentOrganizer.UI.VeiwModels.EntitiesVM
{
    public class PlayerRatingViewModel : INotifyPropertyChanged
    {


        private ObservableCollection<PlayerModel> _players;
        public ObservableCollection<PlayerModel> Players
        {
            get { return _players; }
            set
            {
                _players = value;
                OnPropertyChanged(nameof(Players));
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
