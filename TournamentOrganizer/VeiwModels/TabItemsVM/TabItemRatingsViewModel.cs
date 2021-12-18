using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TournamentOrganizer.UI.VeiwModels.EntitiesVM;

namespace TournamentOrganizer.UI.VeiwModels.TabItemsVM
{
    public class TabItemRatingsViewModel : BaseViewModel
    {
        public TabItemRatingsViewModel()
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

        public DataGrid dataGrid;

       

    }
}
