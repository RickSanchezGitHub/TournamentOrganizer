using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service.PlayerService;
using TournamentOrganizer.BusinessLayer.Service.TeamPlayerService;
using TournamentOrganizer.BusinessLayer.Service.TeamService;
using TournamentOrganizer.UI.Commands.TabItemPlayerCommands;
using TournamentOrganizer.UI.Commands.TeamCommands;

namespace TournamentOrganizer.UI.VeiwModels
{
    public class TabItemTeamViewModel : INotifyPropertyChanged
    {
        private readonly ITeamService _teamService;

        private readonly ITeamPLayerService _teamPlayerService;
        private readonly IPlayerService _playerService;

        public ICommand AddTeamCommand { get; set; }
        public ICommand BackTeamCommand { get; set; }
        public ICommand DeleteTeamCommand { get; set; }
        public ICommand GetAllTeamCommand { get; set; }
        public ICommand GetByIdTeamCommand { get; set; }
        public ICommand AddSaveTeamCommand { get; set; }
        public ICommand UpdateTeamCommand { get; set; }
        public ICommand InitializeTeamCommand { get; set; }
        public ICommand AddPlayerForTeamCommand { get; set; }
        public ICommand DeletePlayerForTeamCommand { get; set; }
        public ICommand GetAllPlayerCommand { get; set; }
        public ICommand UpdateSaveTeamCommand { get; set; }
        public ICommand AddPlayerToTmpList { get; set; }
        public ICommand GetTeamPlayers { get; set; }
        public ICommand RemovePlayerFromTmpListForAdd { get; set; }

        public TabItemTeamViewModel()
        {
            _teamService = new TeamService();
            _playerService = new PlayerService();
            _teamPlayerService = new TeamPlayerService();            
            AddTeamCommand = new AddTeamCommand(this);            
            BackTeamCommand = new BackTeamCommand(this);            
            AddPlayerForTeamCommand = new AddPlayerForTeamCommand(this, _teamPlayerService);
            DeletePlayerForTeamCommand = new DeletePlayerForTeamCommand(this, _teamPlayerService);
            GetAllPlayerCommand = new GetAllPlayerCommand(this, _playerService);
            DeleteTeamCommand = new DeleteTeamCommand(this, _teamService);            
            GetAllTeamCommand = new GetAllTeamCommand(this, _teamService);            
            GetByIdTeamCommand = new GetByIdTeamCommand(this, _teamService);            
            AddSaveTeamCommand = new AddSaveTeamCommand(this, _teamService);            
            UpdateTeamCommand = new UpdateTeamCommand(this, _teamService);            
            InitializeTeamCommand = new InitializeTeamCommand(this, _teamService, _playerService);
            UpdateSaveTeamCommand = new UpdateSaveTeamCommand(this, _teamService, _teamPlayerService);
            AddPlayerToTmpList = new AddPlayerToTmpList(this);
            GetTeamPlayers = new GetTeamPlayers(this, _teamService);
            RemovePlayerFromTmpListForAdd = new RemovePlayerFromTmpListForAdd(this, _teamPlayerService);
            VisibilityColumnAddTeam = Visibility.Collapsed;
            VisibilityColumnUpdateTeam = Visibility.Collapsed;
        }

        private ObservableCollection<PlayerModel> _availablePlayersToAddInTeam;

        public ObservableCollection<PlayerModel> AvailablePlayersToAddInTeam
        {
            get
            {
                return _availablePlayersToAddInTeam ?? new ObservableCollection<PlayerModel>();
            }
            set
            {
                _availablePlayersToAddInTeam = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<TeamModel> _teams;

        public ObservableCollection<TeamModel> Teams
        {
            get
            {
                return _teams ?? new ObservableCollection<TeamModel>();
            }
            set
            {
                _teams = value;
                OnPropertyChanged(nameof(Teams));
            }
        }
        private ObservableCollection<PlayerModel> _players;       

        public ObservableCollection<PlayerModel> Players
        {
            get
            {
                return _players ?? new ObservableCollection<PlayerModel>();
            }
            set
            {
                _players = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<PlayerModel> _playersToAddInTeam = new ObservableCollection<PlayerModel>();

        public ObservableCollection<PlayerModel> PlayersToAddInTeam
        {
            get
            {
                return _playersToAddInTeam ?? new ObservableCollection<PlayerModel>();
            }
            set
            {
                _playersToAddInTeam = value;
                OnPropertyChanged();
            }
        }

        private TeamModel _selectedTeam;
        public TeamModel SelectedTeam
        {
            get => _selectedTeam;
            set
            {
                _selectedTeam = value;
                OnPropertyChanged(nameof(SelectedTeam));
            }
        }

        private PlayerModel _selectedPlayer;
        public PlayerModel SelectedPlayer
        {
            get => _selectedPlayer;
            set
            {
                _selectedPlayer = value;
                OnPropertyChanged(nameof(SelectedPlayer));
            }
        }

        private Visibility _visibilityColumnAddTeam;

        public Visibility VisibilityColumnAddTeam 
        {
            get => _visibilityColumnAddTeam;
            set
            {
                _visibilityColumnAddTeam = value;
                OnPropertyChanged(nameof(VisibilityColumnAddTeam));
            }
        }

        private Visibility _visibilityColumnUpdateTeam;

        public Visibility VisibilityColumnUpdateTeam
        {
            get => _visibilityColumnUpdateTeam;
            set
            {
                _visibilityColumnUpdateTeam = value;
                OnPropertyChanged(nameof(VisibilityColumnUpdateTeam));
            }
        }

        private Visibility _visibilitySaveButton;
        public Visibility VisibilitySaveButton
        {
            get => _visibilitySaveButton;
            set
            {
                _visibilitySaveButton = value;
                OnPropertyChanged(nameof(VisibilitySaveButton));
            }
        }

        private string _textBoxName;
        public string TextBoxName
        {
            get => _textBoxName;
            set
            {
                _textBoxName = value;
                OnPropertyChanged(nameof(TextBoxName));
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
