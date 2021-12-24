using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.Commands.TeamCommands;

namespace TournamentOrganizer.UI.VeiwModels
{
    public class TabItemTeamViewModel : INotifyPropertyChanged
    {
        private readonly ITeamService _teamService;

        private ObservableCollection<TeamModel> _teams;
        public ObservableCollection<TeamModel> Teams {
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

        public ICommand DeleteTeamCommand { get; set; }

        public ICommand GetAllTeamCommand { get; set; }

        public ICommand GetByIdTeamCommand { get; set; }

        public ICommand InsertTeamCommand { get; set; }

        public ICommand UpdateTeamCommand { get; set; }

        public ICommand InitializeTeamCommand { get; set; }

        public TabItemTeamViewModel()
        {
            _teamService = new TeamService();
            DeleteTeamCommand = new DeleteTeamCommand(this, _teamService);
            GetAllTeamCommand = new GetAllTeamCommand(this, _teamService);
            GetByIdTeamCommand = new GetByIdTeamCommand(this, _teamService);
            InsertTeamCommand = new InsertTeamCommand(this, _teamService);
            UpdateTeamCommand = new UpdateTeamCommand(this, _teamService);
            InitializeTeamCommand = new InitializeTeamCommand(this, _teamService);
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



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
