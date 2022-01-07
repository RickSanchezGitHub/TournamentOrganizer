using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.BusinessLayer.Service.TeamService;
using TournamentOrganizer.UI.Command;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TeamCommands
{
    public class UpdateTeamCommand : CommandBase
    {
        private readonly TabItemTeamViewModel _viewModel;
        private readonly ITeamService _teamService;
        public UpdateTeamCommand(TabItemTeamViewModel viewModel, ITeamService teamService)
        {
            _viewModel = viewModel;
            _teamService = teamService;
        }
        public override void Execute(object parameter)
        {
            _viewModel.VisibilityColumnAddTeam = Visibility.Collapsed;
            _viewModel.VisibilityColumnUpdateTeam = Visibility.Visible;
            _viewModel.VisibilitySaveButton = Visibility.Visible;
            _viewModel.TextBoxName = _viewModel.SelectedTeam.Name;
        }
    }
}
