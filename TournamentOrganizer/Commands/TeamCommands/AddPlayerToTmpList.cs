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
    public class AddPlayerToTmpList : CommandBase
    {
        private readonly TabItemTeamViewModel _viewModel;

        private readonly ITeamPLayerService _teamPlayerService;
        public AddPlayerToTmpList(TabItemTeamViewModel viewModel, ITeamPLayerService teamPlayerService)
        {
            _viewModel = viewModel;
            _teamPlayerService = teamPlayerService;
        }
        public override void Execute(object parameter)
        {
            _viewModel.PlayersToAddInTeam.Add((PlayerModel)_viewModel.SelectedPlayer.Clone());
            _viewModel.AvailablePlayersToAddInTeam.Remove(_viewModel.SelectedPlayer);
        }
    }
}
