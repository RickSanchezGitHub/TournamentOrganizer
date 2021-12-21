using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TournamentOrganizer.BusinessLayer.Models;

namespace TournamentOrganizer.UI.VeiwModels
{
    public class TabItemPlayerViewModel : BaseViewModel
    {
        public TabItemPlayerViewModel()
        {
            Players = new ObservableCollection<PlayerModel>();
            WidthGridAddPlayer = new GridLength(0, GridUnitType.Star);
            WidthGridPlayerInfo = new GridLength(0, GridUnitType.Star);
            StateMainDataGrid = true;
           
            

        }
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
      
        private PlayerModel _selectedPlayer;
        public PlayerModel SelectedPlayer
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

        private string _textBoxFirstNameText;
        public string TextBoxFirstNameText
        {
            get { return _textBoxFirstNameText; }
            set
            {
                _textBoxFirstNameText = value;
                OnPropertyChanged(nameof(TextBoxFirstNameText));
            }
        }

        private string _textBoxLastNameText;
        public string TextBoxLastNameText
        {
            get { return _textBoxLastNameText; }
            set
            {
                _textBoxLastNameText = value;
                OnPropertyChanged(nameof(TextBoxLastNameText));
            }
        }

        private string _textBoxNickNameText;
        public string TextBoxNickNameText
        {
            get { return _textBoxNickNameText; }
            set
            {
                _textBoxNickNameText = value;
                OnPropertyChanged(nameof(TextBoxNickNameText));
            }
        }

        private string _textBoxEmailText;
        public string TextBoxEmailText
        {
            get { return _textBoxEmailText; }
            set
            {
                _textBoxEmailText = value;
                OnPropertyChanged(nameof(TextBoxEmailText));
            }
        }

        private DateTime _datePickerBirthdaySelectedDate;
        public DateTime DatePickerBirthdaySelectedDate
        {
            get { return _datePickerBirthdaySelectedDate; }
            set
            {
                _datePickerBirthdaySelectedDate = value;
                OnPropertyChanged(nameof(DatePickerBirthdaySelectedDate));
            }
        }
    }
}