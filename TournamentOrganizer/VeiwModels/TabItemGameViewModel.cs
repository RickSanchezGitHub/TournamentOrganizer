using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace TournamentOrganizer.UI.VeiwModels
{
    public class TabItemGameViewModel: BaseViewModel
    {
        public TabItemGameViewModel()
        {
            Games = new ObservableCollection<GameViewModel>();
        }
        private ObservableCollection<GameViewModel> _games;
        public ObservableCollection<GameViewModel> Games
        {
            get { return _games; }
            set
            {
                _games = value;
                OnPropertyChanged(nameof(Games));
            }
        }
    }
}
