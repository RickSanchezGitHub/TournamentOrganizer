using TournamentOrganizer.BusinessLayer.Service.TeamService;
using TournamentOrganizer.UI.Command;
using TournamentOrganizer.UI.Validation;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TeamCommands
{
    class GetByIdTeamCommand : CommandBase
    {
        private readonly TabItemTeamViewModel _viewModel;
        private readonly ITeamService _teamService;

        public GetByIdTeamCommand(TabItemTeamViewModel viewModel, ITeamService teamService)
        {
            _viewModel = viewModel;
            _teamService = teamService;
        }

        public override void Execute(object parameter)
        {
            try
            {
                var team = _teamService.GetById(_viewModel.SelectedTeam.Id);
                _viewModel.Teams.Add(team);
            }
            catch
            {
                HelperExceptionMessage.HelperMessageBox("Help");
            }
        }
    }
}
