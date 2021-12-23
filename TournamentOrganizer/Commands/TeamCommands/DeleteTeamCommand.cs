using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.Command;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TeamCommands
{
    public class DeleteTeamCommand : CommandBase
    {
        private readonly TabItemTeamViewModel _viewModel;
        private readonly ITeamService _teamService;
        public DeleteTeamCommand(TabItemTeamViewModel viewModel, ITeamService teamService)
        {
            _viewModel = viewModel;
            _teamService = teamService;
        }

        public override void Execute(object parameter)
        {
            _teamService.Delete(_viewModel.SelectedTeam.Id);
            _viewModel.Teams.Remove(_viewModel.SelectedTeam);
        }
    }
}
