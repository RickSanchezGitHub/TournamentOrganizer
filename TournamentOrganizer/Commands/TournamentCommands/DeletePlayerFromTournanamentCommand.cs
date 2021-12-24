using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TournamentCommands
{
    public class DeletePlayerFromTournanamentCommand : CommandBase
    {
        private readonly TabItemTournamentsViewModel _viewModel;
        private readonly ITournamentService _tournamentService;

        public DeletePlayerFromTournanamentCommand(TabItemTournamentsViewModel viewModel, ITournamentService tournamentService) : base()
        {
            _viewModel = viewModel;
            _tournamentService = tournamentService;
        }

        public override void Execute(object parameter)
        {
            PlayerModel player = _viewModel.SelectedTournamentParticipant as PlayerModel;
            _tournamentService.DeletePlayerFromTournament(player.Id, _viewModel.SelectedTournament.Id);
            _viewModel.TournamentParticipants.Remove(_viewModel.SelectedTournamentParticipant);
        }
    }
}
