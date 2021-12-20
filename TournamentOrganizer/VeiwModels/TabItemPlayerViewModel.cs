using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TournamentOrganizer.UI.VeiwModels
{
    public class TabItemPlayerViewModel : BaseViewModel
    {
        public TabItemPlayerViewModel()
        {
            Players = new ObservableCollection<PlayerViewModel>();
            WidthGridAddPlayer = new GridLength(0, GridUnitType.Star);
            WidthGridPlayerInfo = new GridLength(0, GridUnitType.Star);
            StateMainDataGrid = true;
        }
        private ObservableCollection<PlayerViewModel> _players;
        public ObservableCollection<PlayerViewModel> Players
        {
            get { return _players; }
            set
            {
                _players = value;
                OnPropertyChanged(nameof(Players));
            }
        }

        private GridLength? _widthGridAddPlayer;

        public GridLength? WidthGridAddPlayer
        {
            get { return _widthGridAddPlayer; }
            set
            {
                _widthGridAddPlayer = value;
                OnPropertyChanged(nameof(WidthGridAddPlayer));
            }
        }
        private GridLength? _widthGridPlayerInfo;

        public GridLength? WidthGridPlayerInfo
        {
            get { return _widthGridPlayerInfo; }
            set
            {
                _widthGridPlayerInfo = value;
                OnPropertyChanged(nameof(WidthGridPlayerInfo));
            }
        }
        private PlayerViewModel _selectedPlayer;
        public PlayerViewModel SelectedPlayer
        {
            get { return _selectedPlayer; }
            set
            {
                _selectedPlayer = value;
                OnPropertyChanged(nameof(SelectedPlayer));
            }
        }

        private bool _stateMainDataGrid;
        public bool StateMainDataGrid
        {
            get { return _stateMainDataGrid; }
            set
            {
                _stateMainDataGrid = value;
                OnPropertyChanged(nameof(StateMainDataGrid));
            }
        }
    }
}