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
            var games = _tournamentService.GetAllGames();
            var tournaments = _tournamentService.GetAllTournaments();

            _viewModel.Games.Clear();
            _viewModel.Tournaments.Clear();
      

            foreach (var item in games)
            {
                _viewModel.Games.Add(item);
            }

            foreach (var item in tournaments)
            {
                _viewModel.Tournaments.Add(item);
            }

        }
    }
}
