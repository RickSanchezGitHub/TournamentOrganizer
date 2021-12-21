using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.DataLayer.Entities;
using TournamentOrganizer.UI.VeiwModels.EntitiesVM;

namespace TournamentOrganizer.UI.VeiwModels.TabItemsVM
{
    public class TabItemRatingsViewModel : BaseViewModel
    {
        public TabItemRatingsViewModel()
        {
            Games = new ObservableCollection<GameModel>();
            ResultsTournamentPlayer = new ObservableCollection<ResultTournamentPlayerModel>();
        }

        private ObservableCollection<GameModel> _games;
        public ObservableCollection<GameModel> Games
        {
            get { return _games; }
            set
            {
                _games = value;
                OnPropertyChanged(nameof(Games));
            }
        }

        private ObservableCollection<ResultTournamentPlayerModel> _resultsTournamentPlayer;
        public ObservableCollection<ResultTournamentPlayerModel> ResultsTournamentPlayer
        {
            get { return _resultsTournamentPlayer; }
            set
            {
                _resultsTournamentPlayer = value;
                OnPropertyChanged(nameof(ResultsTournamentPlayer));
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

