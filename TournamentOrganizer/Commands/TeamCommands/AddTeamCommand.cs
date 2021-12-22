using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.UI.Command;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TeamCommands
{
    public class AddTeamCommand : CommandBase
    {
        private TabItemTeamViewModel _viewModel;
        public AddTeamCommand(TabItemTeamViewModel viewModel) : base()
        {
            _viewModel = viewModel;
            //   _teamService = _viewModel._teamService;
        }

        public override void Execute(object parameter)
        {
           

        }
    }
}
