using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TournamentCommands
{
    public class DeleteParticipantFromTournanamentCommand : CommandBase
    {
        private readonly TabItemTournamentsViewModel _viewModel;
        private readonly ITournamentService _tournamentService;

        public DeleteParticipantFromTournanamentCommand(TabItemTournamentsViewModel viewModel, ITournamentService tournamentService) : base()
        {
            _viewModel = viewModel;
            _tournamentService = tournamentService;
        }

        public override void Execute(object parameter)
        {
            if (_viewModel.SelectedTournament.OnlyForTeams)
            {
                _tournamentService.DeleteTeamFromTournament(_viewModel.SelectedTournamentParticipant.Id, _viewModel.SelectedTournament.Id);
            }
            else
            {
                _tournamentService.DeletePlayerFromTournament(_viewModel.SelectedTournamentParticipant.Id, _viewModel.SelectedTournament.Id);
            }
            _viewModel.TournamentParticipants.Remove(_viewModel.SelectedTournamentParticipant);
        }
    }
}
