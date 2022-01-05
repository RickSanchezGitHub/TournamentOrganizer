using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.GridOfTournamentsCommands
{
    public class ShowTournamentParticipantsCommand : CommandBase
    {
        private TabItemGridOfTournamentsViewModel _viewModel;
        public ShowTournamentParticipantsCommand(TabItemGridOfTournamentsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.VisibilityDataGridShowTournamentParticipants = System.Windows.Visibility.Visible;

        }
    }
}
