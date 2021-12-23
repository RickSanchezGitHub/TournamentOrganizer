using System.Collections.ObjectModel;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TournamentCommands
{
    public class InitializeTournamentCommand : CommandBase
    {
        private readonly TabItemTournamentsViewModel _viewModel;
        private readonly ITournamentService _tournamentService;

        public InitializeTournamentCommand(TabItemTournamentsViewModel viewModel, ITournamentService tournamentService) : base()
        {
            _viewModel = viewModel;
            _tournamentService = tournamentService;
        }

        public override void Execute(object parameter)
        {
            _viewModel.Games = new ObservableCollection<GameModel>(_tournamentService.GetAllGames());
            _viewModel.Tournaments = new ObservableCollection<TournamentModel>(_tournamentService.GetAllTournaments());
        }
    }
}
