using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands
{
    public class CreateRoundCommand: CommandBase
    {
        private TabItemGridOfTournamentsViewModel _viewModel;

        public CreateRoundCommand(TabItemGridOfTournamentsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.SelectedTournament.CreateRound();

        }
    }
}
