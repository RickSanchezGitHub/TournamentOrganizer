using MvvmHelpers;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.Commands.TournamentCommands;

namespace TournamentOrganizer.UI.VeiwModels
{
    public class TabItemTournamentsViewModel : BaseViewModel
    {
        public readonly ITournamentService _tournamentService;
        public ICommand DeleteTournament { get; set; }
        public ICommand SaveTournament { get; set; }
        public ICommand UpdateTournament { get; set; }
        public ICommand AddTournament { get; set; }
        public ICommand BackTournament { get; set; }
        public ICommand EditTournament { get; set; }
        public ICommand InitializeTournaments { get; set; }
        public ICommand GetPlayers { get; set; }
        public ICommand BackPlayers { get; set; }
        public ICommand DeletePlayer { get; set; }

        public ObservableCollection<TournamentModel> Tournaments { get; set; }
        public ObservableCollection<GameModel> Games { get; set; }
        public ObservableCollection<PlayerModel> Players { get; set; }

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


        private string _textboxname;
        public string TextBoxName
        {
            get => _textboxname;
            set
            {
                _textboxname = value;
                OnPropertyChanged(nameof(TextBoxName));
            }
        }

        private DateTime? _datePickerStartDate;
        public DateTime? DatePickerStartDate
        {
            get { return _datePickerStartDate; }
            set
            {
                _datePickerStartDate = value;
                OnPropertyChanged(nameof(DatePickerStartDate));
            }
        }

        private DateTime? _datePickerCloseDate;
        public DateTime? DatePickerCloseDate
        {
            get { return _datePickerCloseDate; }
            set
            {
                _datePickerCloseDate = value;
                OnPropertyChanged(nameof(DatePickerCloseDate));
            }
        }

        private GameModel _selectedGame;
        public GameModel SelectedGame
        {
            get { return _selectedGame; }
            set
            {
                _selectedGame = value;
                OnPropertyChanged(nameof(SelectedGame));
            }
        }

        private Visibility _visibilitySaveButton;
        public Visibility VisibilitySaveButton
        {
            get
            {
                return _visibilitySaveButton;
            }
            set
            {
                _visibilitySaveButton = value;

                OnPropertyChanged(nameof(VisibilitySaveButton));
            }
        }

        private Visibility _visibilityUpdateButton;
        public Visibility VisibilityUpdateButton
        {
            get
            {
                return _visibilityUpdateButton;
            }
            set
            {
                _visibilityUpdateButton = value;

                OnPropertyChanged(nameof(VisibilityUpdateButton));
            }
        }

        private Visibility _visibilityBackPlayersButton;
        public Visibility VisibilityBackPlayersButton
        {
            get
            {
                return _visibilityBackPlayersButton;
            }
            set
            {
                _visibilityBackPlayersButton = value;

                OnPropertyChanged(nameof(VisibilityBackPlayersButton));
            }
        }

        private Visibility _visibilityColumn;
        public Visibility VisibilityColumn
        {
            get
            {
                return _visibilityColumn;
            }
            set
            {
                _visibilityColumn = value;

                OnPropertyChanged(nameof(VisibilityColumn));
            }
        }

        private Visibility _visibilityDataGridTournaments;
        public Visibility VisibilityDataGridTournaments
        {
            get
            {
                return _visibilityDataGridTournaments;
            }
            set
            {
                _visibilityDataGridTournaments = value;

                OnPropertyChanged(nameof(VisibilityDataGridTournaments));
            }
        }

        private Visibility _visibilityDataGridPlayers;
        public Visibility VisibilityDataGridPlayers
        {
            get
            {
                return _visibilityDataGridPlayers;
            }
            set
            {
                _visibilityDataGridPlayers = value;

                OnPropertyChanged(nameof(VisibilityDataGridPlayers));
            }
        }

        private GridLength _gridLength;
        public GridLength GridLength
        {
            get
            {
                return _gridLength;
            }
            set
            {
                _gridLength = value;
                OnPropertyChanged(nameof(GridLength));
            }
        }

        public TabItemTournamentsViewModel()
        {
            _tournamentService = new TournamentService();
            Tournaments = new ObservableCollection<TournamentModel>(_tournamentService.GetAllTournaments());
            Games = new ObservableCollection<GameModel>(_tournamentService.GetAllGames());
            Players = new ObservableCollection<PlayerModel>();
            VisibilityColumn = Visibility.Collapsed;
            VisibilityDataGridPlayers = Visibility.Collapsed;
            VisibilityBackPlayersButton = Visibility.Collapsed;
            DeleteTournament = new DeleteTournamentCommand(this, _tournamentService);
            SaveTournament = new SaveTournamentCommand(this, _tournamentService);
            UpdateTournament = new UpdateTournamentCommand(this, _tournamentService);
            InitializeTournaments = new InitializeTournamentCommand(this, _tournamentService);
            AddTournament = new AddTournamentCommand(this);
            BackTournament = new BackTournamentCommand(this);
            EditTournament = new EditTournamentCommand(this);
            GetPlayers = new GetTournamentPlayers(this, _tournamentService);
            BackPlayers = new BackPlayersCommand(this);
            DeletePlayer = new DeletePlayerFromTournanamentCommand(this, _tournamentService);
        }

    }
}
