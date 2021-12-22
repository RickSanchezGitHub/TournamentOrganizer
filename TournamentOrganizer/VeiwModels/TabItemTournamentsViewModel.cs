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
        public readonly TournamentService _tournamentService;
        public ICommand DeleteTournament { get; set; }
        public ICommand SaveTournament { get; set; }
        public ICommand UpdateTournament { get; set; }
        public ICommand AddTournament { get; set; }
        public ICommand BackTournament { get; set; }
        public ICommand EditTournament { get; set; }


        public ObservableCollection<TournamentModel> Tournaments { get; set; }
        public ObservableCollection<GameModel> Games { get; set; }

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
            //GridLength = new GridLength(0, GridUnitType.Star);
            VisibilityColumn = Visibility.Collapsed;
            DeleteTournament = new DeleteTournamentCommand(this, _tournamentService);
            SaveTournament = new SaveTournamentCommand(this, _tournamentService);
            UpdateTournament = new UpdateTournamentCommand(this, _tournamentService);
            AddTournament = new AddTournamentCommand(this);
            BackTournament = new BackTournamentCommand(this);
            EditTournament = new EditTournamentCommand(this);
        }

    }
}
