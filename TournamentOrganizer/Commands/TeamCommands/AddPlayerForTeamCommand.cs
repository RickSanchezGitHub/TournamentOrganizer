using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.Command;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TeamCommands
{
    public class AddPlayerForTeamCommand : CommandBase
    {
        private readonly TabItemTeamViewModel _viewModel;

        private readonly ITeamPlayerService _teamPlayerService;
        public AddPlayerForTeamCommand(TabItemTeamViewModel viewModel, ITeamPlayerService teamPlayerService)
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
            _viewModel.VisibilityColumn = Visibility.Collapsed;
            _teamPlayerService.Insert(teamPlayerModel);
        }
    }
}
