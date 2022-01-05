using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.DataLayer.Repositories;
using TournamentOrganizer.UI.Commands;
using TournamentOrganizer.UI.Commands.TabItemPlayerCommands;

namespace TournamentOrganizer.UI.VeiwModels
{
    public class TabItemPlayerViewModel : BaseViewModel
    {
        public TabItemPlayerViewModel()
        {
            _playerService = new PlayerService();
            Players = new ObservableCollection<PlayerModel>(_playerService.GetAll());
            WidthGridAddPlayer = new GridLength(0, GridUnitType.Star);
            WidthGridPlayerInfo = new GridLength(0, GridUnitType.Star);
            StateMainDataGrid = true;
            VisibilityButtonAddSave = Visibility.Hidden;
            VisibilityButtonEditSave = Visibility.Hidden;
            IsEnabledButtonAddSave = false;
            IsEnabledButtonEditSave = false;
            Teams = new();
            DeletePlayer = new DeletePlayerCommand(this, _playerService);
            AddSavePlayer = new AddSavePlayerCommand(this, _playerService);
            GetInfoAboutPlayer = new GetInfoAboutPlayerCommand(this, _playerService);
            EditSavePlayer = new EditSavePlayerCommand(this, _playerService);
            BackFromInfo = new BackFromInfoCommand(this);
            BackFromAdd = new BackFromAddCommand(this);
            AddClick = new AddClickCommand(this);
            EditClick = new EditClickCommand(this);
            IsEnabledButtonAdd = true;

        }

        private  IPlayerService _playerService;

        

        public ObservableCollection<PlayerModel> Players {get; set;}

        

        public ObservableCollection<TeamModel> Teams { get; set; }
       

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

        private PlayerModel _selectedDeletePlayer;

        public PlayerModel SelectedDeletePlayer
        {
            get { return _selectedDeletePlayer; }
            set
            {
                _selectedDeletePlayer = value;
                OnPropertyChanged(nameof(SelectedDeletePlayer));
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

        private bool _isEnabledButtonAddSave;
        public bool IsEnabledButtonAddSave
        {
            get { return _isEnabledButtonAddSave; }
            set
            {
                _isEnabledButtonAddSave = value;
                OnPropertyChanged(nameof(IsEnabledButtonAddSave));
            }
        }

        private Visibility _visibilityButtonAddSave;
        public Visibility VisibilityButtonAddSave
        {
            get { return _visibilityButtonAddSave; }
            set
            {
                _visibilityButtonAddSave = value;
                OnPropertyChanged(nameof(VisibilityButtonAddSave));
            }
        }

        private bool _isEnabledButtonEditSave;
        public bool IsEnabledButtonEditSave
        {
            get { return _isEnabledButtonEditSave; }
            set
            {
                _isEnabledButtonEditSave = value;
                OnPropertyChanged(nameof(IsEnabledButtonEditSave));
            }
        }

        private Visibility _visibilityButtonEditSave;
        public Visibility VisibilityButtonEditSave
        {
            get { return _visibilityButtonEditSave; }
            set
            {
                _visibilityButtonEditSave = value;
                OnPropertyChanged(nameof(VisibilityButtonEditSave));
            }
        }

        private Visibility _visibilityDataGridShowTeamsPlayer;
        public Visibility VisibilityDataGridShowTeamsPlayer
        {
            get { return _visibilityDataGridShowTeamsPlayer; }
            set
            {
                _visibilityDataGridShowTeamsPlayer = value;
                OnPropertyChanged(nameof(VisibilityDataGridShowTeamsPlayer));
            }
        }

        private Visibility _visibilityLabelPlayerWithoutTeams;
        public Visibility VisibilityLabelPlayerWithoutTeams
        {
            get { return _visibilityLabelPlayerWithoutTeams; }
            set
            {
                _visibilityLabelPlayerWithoutTeams = value;
                OnPropertyChanged(nameof(VisibilityLabelPlayerWithoutTeams));
            }
        }

        public ICommand DeletePlayer { get; set; }
     

        
        public ICommand AddSavePlayer { get; set; }
      

        public ICommand AddClick { get; set; }
      
        public ICommand EditClick { get; set; }
       
        public ICommand EditSavePlayer { get; set; }
       
        public ICommand GetInfoAboutPlayer { get; set; }

        public ICommand BackFromInfo { get; set; }
       
        public ICommand BackFromAdd { get; set; }
        
        private bool _isEnabledButtonAdd;

        public bool IsEnabledButtonAdd
        {
            get { return _isEnabledButtonAdd; }
            set
            {
                _isEnabledButtonAdd = value;
                OnPropertyChanged(nameof(IsEnabledButtonAdd));
            }
        }
    }
}