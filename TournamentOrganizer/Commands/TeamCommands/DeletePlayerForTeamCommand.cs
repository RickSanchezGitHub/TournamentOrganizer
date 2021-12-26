using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.Command;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TeamCommands
{
    class DeletePlayerForTeamCommand : CommandBase
    {
        private readonly TabItemTeamViewModel _viewModel;

        private readonly ITeamPlayerService _teamPlayerService;
        public DeletePlayerForTeamCommand(TabItemTeamViewModel viewModel, ITeamPlayerService teamPlayerService)
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
            _teamPlayerService.Delete(teamPlayerModel);
        }
    }
}
