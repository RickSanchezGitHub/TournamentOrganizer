using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.Commands.TeamCommands;

namespace TournamentOrganizer.UI.VeiwModels
{
    public class TabItemTeamViewModel : INotifyPropertyChanged
    {
        private readonly ITeamService _teamService;

        private readonly ITeamPlayerService _teamPlayerService;

        public ICommand AddTeamCommand { get; set; }
        public ICommand BackTeamCommand { get; set; }
        public ICommand DeleteTeamCommand { get; set; }
        public ICommand GetAllTeamCommand { get; set; }
        public ICommand GetByIdTeamCommand { get; set; }
        public ICommand InsertTeamCommand { get; set; }
        public ICommand UpdateTeamCommand { get; set; }
        public ICommand InitializeTeamCommand { get; set; }
        public ICommand AddPlayerForTeamCommand { get; set; }
        public ICommand DeletePlayerForTeamCommand { get; set; }

        public TabItemTeamViewModel()
        {
            _teamService = new TeamService();

            _teamPlayerService = new TeamPlayerService();
            
            AddTeamCommand = new AddTeamCommand(this);
            
            BackTeamCommand = new BackTeamCommand(this);
            
            AddPlayerForTeamCommand = new AddPlayerForTeamCommand(this, _teamPlayerService);

            DeletePlayerForTeamCommand = new DeletePlayerForTeamCommand(this, _teamPlayerService);

            DeleteTeamCommand = new DeleteTeamCommand(this, _teamService);
            
            GetAllTeamCommand = new GetAllTeamCommand(this, _teamService);
            
            GetByIdTeamCommand = new GetByIdTeamCommand(this, _teamService);
            
            InsertTeamCommand = new InsertTeamCommand(this, _teamService);
            
            UpdateTeamCommand = new UpdateTeamCommand(this, _teamService);
            
            InitializeTeamCommand = new InitializeTeamCommand(this, _teamService);
            
            VisibilityColumn = Visibility.Collapsed;
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

        private Visibility _visibilityColumn;

        public Visibility VisibilityColumn 
        {
            get => _visibilityColumn;
            set
            {
                _visibilityColumn = value;
                OnPropertyChanged(nameof(VisibilityColumn));
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
