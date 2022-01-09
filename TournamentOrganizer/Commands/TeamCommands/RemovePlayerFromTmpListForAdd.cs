using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service.TeamPlayerService;
using TournamentOrganizer.UI.Command;
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
            var player = (PlayerModel)_viewModel.SelectedPlayer.Clone();
            _viewModel.PlayersToAddInTeam.Remove(_viewModel.SelectedPlayer);
            _viewModel.AvailablePlayersToAddInTeam.Add(player);
        }
    }
}
