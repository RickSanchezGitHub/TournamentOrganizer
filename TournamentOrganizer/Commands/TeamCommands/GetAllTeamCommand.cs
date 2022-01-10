using TournamentOrganizer.BusinessLayer.Service.TeamService;
using TournamentOrganizer.UI.Command;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TeamCommands
{
    public class GetAllTeamCommand : CommandBase
    {
        private TabItemTeamViewModel _viewModel;
        private ITeamService _teamService;

        public GetAllTeamCommand(TabItemTeamViewModel viewModel, ITeamService teamService) : base()
        {
            _viewModel = viewModel;
            _teamService = teamService;
        }

        public override void Execute(object parameter)
        {
            var teams = _teamService.GetAll();
            foreach (var item in teams)
            {
                _viewModel.Teams.Add(item);
            }
        }
    }
}
