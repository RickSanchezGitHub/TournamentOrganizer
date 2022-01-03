using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands
{
    public class SetWinnerCommand : CommandBase
    {
        private TabItemGridOfTournamentsViewModel _viewModel;
        public SetWinnerCommand(TabItemGridOfTournamentsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.VisibilityButtonSetWinner = Visibility.Collapsed;
            _viewModel.VisibilityButtonUnsetWinner = Visibility.Visible;

        }
    }
}
