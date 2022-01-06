using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TournamentOrganizer.BusinessLayer.Configuration;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.Commands;
using TournamentOrganizer.UI.Commands.GridOfTournamentsCommands;

namespace TournamentOrganizer.UI.VeiwModels
{
    public class TabItemGridOfTournamentsViewModel : BaseViewModel
    {
        public ObservableCollection<TournamentModel> Tournaments { get; set; }
        public ObservableCollection<PlayerModel> Players { get; set; }
        public ObservableCollection<ParticipantTournamentResult> ParticipantTournamentResults { get; set; }

        private ITournamentService _tournamentService;
        private IPlayerService _playerService;
        public TabItemGridOfTournamentsViewModel()
        {
            _tournamentService = new TournamentService();
            _playerService = new PlayerService();
            TournamentSelect = new TournamentSelectCommand(this, _tournamentService);
            Tournaments = new ObservableCollection<TournamentModel>();
            CreateRound = new CreateRoundCommand(this);
            SetWinner = new SetWinnerCommand(this);
            SetDraw = new SetDrawCommand(this);
            BackFromResolveMatch = new BackFromResolveMatchCommand(this);
            ShowTournamentParticipants = new ShowTournamentParticipantsCommand(this);
            LoadTournaments = new LoadTournamentsCommand(this, _tournamentService);
            ResolveMatch = new ResolveMatchCommand(this);
            Command = new RoutedCommand("Command", typeof(Button));
            Players = new();
            SelctedMatchInTreeView = new();
            VisibilityStackPanelMatchResolve = Visibility.Collapsed;
            VisibilityButtonShowTournamentParticipants = Visibility.Collapsed;
            VisibilityDataGridShowTournamentParticipants = Visibility.Collapsed;
            InitialData();
        }

        private TournamentModel _selectedTournament;
        public TournamentModel SelectedTournament
        {
            get { return _selectedTournament; }
            set
            {
                _selectedTournament = value;
                OnPropertyChanged(nameof(SelectedTournament));
                if (_selectedTournament != null)
                {
                    VisibilityButtonShowTournamentParticipants = Visibility.Visible;
                }
                
            }
        }

        private MatchModel _selctedMatchInTreeView;
        public MatchModel SelctedMatchInTreeView
        {
            get { return _selctedMatchInTreeView; }
            set
            {
                _selctedMatchInTreeView = value;
                OnPropertyChanged(nameof(SelctedMatchInTreeView));

            }
        }

        private PlayerModel _selctedPlayerInComboBox;
        public PlayerModel SelctedPlayerInComboBox
        {
            get { return _selctedPlayerInComboBox; }
            set
            {
                _selctedPlayerInComboBox = value;
                OnPropertyChanged(nameof(SelctedPlayerInComboBox));

            }
        }

        private Visibility _visibilityStackPanelMatchResolve;
        public Visibility VisibilityStackPanelMatchResolve
        {
            get { return _visibilityStackPanelMatchResolve; }
            set
            {
                _visibilityStackPanelMatchResolve = value;
                OnPropertyChanged(nameof(VisibilityStackPanelMatchResolve));
            }
        }
        private Visibility _visibilityButtonShowTournamentParticipants;
        public Visibility VisibilityButtonShowTournamentParticipants
        {
            get { return _visibilityButtonShowTournamentParticipants; }
            set
            {
                _visibilityButtonShowTournamentParticipants = value;
                OnPropertyChanged(nameof(VisibilityButtonShowTournamentParticipants));
            }
        }

        private Visibility _visibilityDataGridShowTournamentParticipants;
        public Visibility VisibilityDataGridShowTournamentParticipants
        {
            get { return _visibilityDataGridShowTournamentParticipants; }
            set
            {
                _visibilityDataGridShowTournamentParticipants = value;
                OnPropertyChanged(nameof(VisibilityDataGridShowTournamentParticipants));
            }
        }

        private Button _selectedButton;
        public Button SelectedButton
        {
            get { return _selectedButton; }
            set
            {
                _selectedButton = value;
                OnPropertyChanged(nameof(SelectedButton));
            }
        }

        public ICommand TournamentSelect { get; set; }
        public ICommand CreateRound { get; set; }
        public ICommand SetWinner { get; set; }
        public ICommand SetDraw { get; set; }
        public ICommand BackFromResolveMatch { get; set; }
        public ICommand ShowTournamentParticipants { get; set; }
        public ICommand LoadTournaments { get;set; }
        public ICommand ResolveMatch { get; set; }
        public RoutedCommand Command { get; set; }

        public void Command_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var button = (Button)sender;
            var data = button.DataContext;
            SelctedMatchInTreeView = (MatchModel)data;
            VisibilityStackPanelMatchResolve = Visibility.Visible;
            VisibilityDataGridShowTournamentParticipants = Visibility.Collapsed;
        }

        private void InitialData()
        {
            GameService game = new GameService();
            PlayerService playerService = new PlayerService();

            TournamentModel tour = new TournamentModel
            {
                Name = "Experience tour",
                Game = game.GameSelectById(7),
                StartDate = DateTime.Now.AddDays(-10),
                CloseDate = DateTime.Now
            };
            var listPlayers = playerService.GetAll();

            foreach (PlayerModel item in listPlayers)
            {
                tour.Participants.Add(item);
                tour.ParticipantsResults.Add(new ParticipantTournamentResult(item));
            }

            tour.StartTournament();
            Tournaments.Add(tour);
        }
    }
}
