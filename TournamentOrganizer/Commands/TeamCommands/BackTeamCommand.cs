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
    public class BackTeamCommand : CommandBase
    {
        private TabItemTeamViewModel _viewModel;

        public BackTeamCommand(TabItemTeamViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.VisibilityColumnAddTeam = Visibility.Collapsed;
            _viewModel.VisibilityColumnUpdateTeam = Visibility.Collapsed;
        }
    }
}
