using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using TournamentOrganizer.DataLayer.Entities;
using TournamentOrganizer.UI.VeiwModels.EntitiesVM;

namespace TournamentOrganizer.UI.VeiwModels.TabItemsVM
{
    public class TabItemRatingsViewModel : BaseViewModel
    {
        public TabItemRatingsViewModel()
        {
            Games = new ObservableCollection<GameViewModel>();
            Players = new ObservableCollection<PlayerResultViewModel>();
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

        private ObservableCollection<PlayerResultViewModel> _players;
        public ObservableCollection<PlayerResultViewModel> Players
        {
            get { return _players; }
            set
            {
                _players = value;
                OnPropertyChanged(nameof(Players));
            }
        }

        private ObservableCollection<TeamResultViewModel> _teams;
        public ObservableCollection<TeamResultViewModel> Teams
        {
            get { return _teams; }
            set
            {
                _teams = value;
                OnPropertyChanged(nameof(Teams));
            }
        }

        public List<string> dataGridColumnHeadersPlayer = new List<string>
        {
            "Имя", "Фамилия", "Псевдоним", "Рейтинг"
        };

        public List<string> dataGridColumnHeadersTeam = new List<string>
        {
            "Название", "Рейтинг"
        };

        
    }
}

