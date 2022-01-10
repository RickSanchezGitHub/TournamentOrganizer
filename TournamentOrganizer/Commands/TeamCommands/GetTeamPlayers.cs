using System.Linq;
using TournamentOrganizer.BusinessLayer.Service.TeamService;
using TournamentOrganizer.UI.Command;
using TournamentOrganizer.UI.Validation;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TeamCommands
{
    public class GetTeamPlayers : CommandBase
    {
        private readonly TabItemTeamViewModel _viewModel;
        private readonly ITeamService _teamService;

        public GetTeamPlayers(TabItemTeamViewModel viewModel, ITeamService teamService)
        {
            _viewModel = viewModel;
            _teamService = teamService;
        }

        public override void Execute(object parameter)
        {
            try
            {

                var teamWithPlayers = _teamService.GetById(_viewModel.SelectedTeam.Id);
                if (teamWithPlayers.Players.Count >= 1 && teamWithPlayers.Players.FirstOrDefault() != null)
                {
                    _viewModel.SelectedTeam.Players = teamWithPlayers.Players;
                }
            }
            catch
            {
                HelperExceptionMessage.HelperMessageBox("Help");
            }
        }
    }
}
