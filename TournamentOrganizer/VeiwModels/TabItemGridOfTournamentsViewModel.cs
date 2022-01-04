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
            Tournaments = new ObservableCollection<TournamentModel>(_tournamentService.GetAllTournaments());
            CreateRound = new CreateRoundCommand(this);
            SetWinner = new SetWinnerCommand(this);
            SetDraw = new SetDrawCommand(this);
            BackFromResolveMatch = new BackFromResolveMatchCommand(this);
            Players = new();
            SelctedMatchInTreeView = new();
            VisibilityStackPanelMatchResolve = Visibility.Hidden;
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

        public ICommand TournamentSelect { get; set; }
        public ICommand CreateRound { get; set; }
        public ICommand SetWinner { get; set; }
        public ICommand SetDraw { get; set; }
        public ICommand BackFromResolveMatch { get; set; }
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
