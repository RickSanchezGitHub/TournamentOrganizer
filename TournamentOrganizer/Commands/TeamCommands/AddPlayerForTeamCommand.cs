using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service.TeamPlayerService;
using TournamentOrganizer.UI.Command;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TeamCommands
{
    public class AddPlayerForTeamCommand : CommandBase
    {
        private readonly TabItemTeamViewModel _viewModel;
        private readonly ITeamPLayerService _teamPlayerService;

        public AddPlayerForTeamCommand(TabItemTeamViewModel viewModel, ITeamPLayerService teamPlayerService)
        {
            _viewModel = viewModel;
            _teamPlayerService = teamPlayerService;
        }

        public override void Execute(object parameter)
        {
            var teamPlayerModel = new TeamPlayerModel
            {
                TeamId = _viewModel.SelectedTeam.Id,
                PlayerId = _viewModel.SelectedPlayer.Id
            };
            _teamPlayerService.Insert(teamPlayerModel);
        }

    }
}
