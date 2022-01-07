using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TournamentOrganizer.UI.Command;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TeamCommands
{
    public class AddTeamCommand : CommandBase
    {
        private TabItemTeamViewModel _viewModel;
        public AddTeamCommand(TabItemTeamViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            _viewModel.VisibilityColumnUpdateTeam = Visibility.Collapsed;
            _viewModel.VisibilityColumnAddTeam = Visibility.Visible;
            _viewModel.VisibilitySaveButton = Visibility.Visible;
            _viewModel.TextBoxName = "";
        }
    }
}
