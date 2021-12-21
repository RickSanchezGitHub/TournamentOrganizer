using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.Commands.TournamentCommands;

namespace TournamentOrganizer.UI.VeiwModels
{
    public class TabItemTournamentsViewModel: BaseViewModel
    {
        public readonly TournamentService _tournamentService;
        private ICommand _deleteTournamentCommand;
        private ObservableCollection<TournamentModel> _tournaments;
        public ObservableCollection<TournamentModel> Tournaments
        {
            get { return _tournaments; }
            set
            {
                _tournaments = value;
                OnPropertyChanged(nameof(Tournaments));
            }
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
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        private string _startDate;
        public string StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }
        private string _closeDate;
        public string CloseDate
        {
            get { return _closeDate; }
            set
            {
                _closeDate = value;
                OnPropertyChanged(nameof(CloseDate));
            }
        }

        private ObservableCollection<GameModel> _games;
        public ObservableCollection<GameModel> Games
        {
            get { return _games; }
            set
            {
                _games = value;
                OnPropertyChanged(nameof(Games));
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



        public TabItemTournamentsViewModel()
        {
            _tournamentService = new TournamentService();
            Tournaments = new ObservableCollection<TournamentModel>(_tournamentService.GetAllTournaments());
            Games = new ObservableCollection<GameModel>(_tournamentService.GetAllGames());

        }

        public ICommand DeleteTournament
        {
            get
            {
                if (_deleteTournamentCommand == null)
                {
                    _deleteTournamentCommand = new DeleteTournamentCommand(this);
                }
                return _deleteTournamentCommand;
            }
        }
    }
}
