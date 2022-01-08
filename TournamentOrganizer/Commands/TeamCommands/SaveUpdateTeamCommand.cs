using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service.TeamPlayerService;
using TournamentOrganizer.BusinessLayer.Service.TeamService;
using TournamentOrganizer.UI.Command;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TeamCommands
{
    public class SaveUpdateTeamCommand : CommandBase
    {
        private readonly TabItemTeamViewModel _viewModel;
        private readonly ITeamService _teamService;
        private readonly ITeamPLayerService _teamPLayerService;
        public SaveUpdateTeamCommand(TabItemTeamViewModel viewModel, ITeamService teamService, ITeamPLayerService teamPLayerService)
        {
            _viewModel = viewModel;
            _teamService = teamService;
            _teamPLayerService = teamPLayerService;
        }
        public override void Execute(object parameter)
        {
            _viewModel.VisibilityColumnUpdateTeam = Visibility.Visible;
            _viewModel.VisibilitySaveButton = Visibility.Visible;

            var teamModel = new TeamModel
            {
                Name = _viewModel.TextBoxName
            };         
            _teamService.Update(_viewModel.SelectedTeam.Id, teamModel);

            foreach(var player in _viewModel.PlayersToAddInTeam)
            {
                var teamPlayerModel = new TeamPlayerModel
                {
                    TeamId = _viewModel.SelectedTeam.Id,
                    PlayerId = player.Id
                };
                _teamPLayerService.Insert(teamPlayerModel);
                _viewModel.SelectedTeam.Players.Add(player);
            }           
            _viewModel.PlayersToAddInTeam.Clear();
            _viewModel.AvailablePlayersToAddInTeam.Clear();
            _viewModel.SelectedTeam.Name = _viewModel.TextBoxName;
            _viewModel.VisibilityColumnAddTeam = Visibility.Collapsed;
            _viewModel.VisibilityColumnUpdateTeam = Visibility.Collapsed;
            _viewModel.VisibilitySaveButton = Visibility.Collapsed;
        }
    }
}
