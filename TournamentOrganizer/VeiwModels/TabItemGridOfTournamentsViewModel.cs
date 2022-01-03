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

namespace TournamentOrganizer.UI.VeiwModels
{
    public class TabItemGridOfTournamentsViewModel : BaseViewModel
    {
        public ObservableCollection<TournamentModel> Tournaments { get; set; }
        public ObservableCollection<PlayerModel> Players { get; set; }


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
            UnSetWinner = new UnSetWinnerCommand(this);
            VisibilityButtonUnsetWinner = Visibility.Collapsed;
            Players = new();
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

        private Visibility _visibilityButtonUnsetWinner;
        public Visibility VisibilityButtonUnsetWinner
        {
            get { return _visibilityButtonUnsetWinner; }
            set
            {
                _visibilityButtonUnsetWinner = value;
                OnPropertyChanged(nameof(VisibilityButtonUnsetWinner));
                
            }
        }
        private Visibility _visibilityButtonSetWinner;
        public Visibility VisibilityButtonSetWinner
        {
            get { return _visibilityButtonSetWinner; }
            set
            {
                _visibilityButtonSetWinner = value;
                OnPropertyChanged(nameof(VisibilityButtonSetWinner));

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
        public ICommand UnSetWinner { get; set; }

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
