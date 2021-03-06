using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service.TeamPlayerService;
using TournamentOrganizer.UI.Command;
using TournamentOrganizer.UI.Validation;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TeamCommands
{
    public class RemovePlayerFromTmpListForAdd : CommandBase
    {
        private readonly TabItemTeamViewModel _viewModel;

        public RemovePlayerFromTmpListForAdd(TabItemTeamViewModel viewModel, ITeamPLayerService teamPlayerService)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            try
            {
                var player = (PlayerModel)_viewModel.SelectedPlayer;
                _viewModel.PlayersToAddInTeam.Remove(_viewModel.SelectedPlayer);
                _viewModel.AvailablePlayersToAddInTeam.Add(player);
            }
            catch
            {
                HelperExceptionMessage.HelperMessageBox("Help");
            }
        }
    }
}
