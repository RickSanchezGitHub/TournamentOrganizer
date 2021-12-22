using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TournamentCommands
{
    public class DeleteTournamentCommand : CommandBase
    {
        private readonly TabItemTournamentsViewModel _viewModel;
        private readonly TournamentService _tournamentService;

        public DeleteTournamentCommand(TabItemTournamentsViewModel viewModel, TournamentService tournamentService) : base()
        {
            _viewModel = viewModel;
            _tournamentService = tournamentService;
        }

        public override void Execute(object parameter)
        {
            _tournamentService.DeleteTournament(_viewModel.SelectedTournament.Id);
            _viewModel.Tournaments.Remove(_viewModel.SelectedTournament);
        }
    }
}
