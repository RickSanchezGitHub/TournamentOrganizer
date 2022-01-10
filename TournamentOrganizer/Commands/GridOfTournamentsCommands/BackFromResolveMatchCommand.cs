using System.Windows;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.GridOfTournamentsCommands
{
    public class BackFromResolveMatchCommand : CommandBase
    {
        private TabItemGridOfTournamentsViewModel _viewModel;
        public BackFromResolveMatchCommand(TabItemGridOfTournamentsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.VisibilityStackPanelMatchResolve = Visibility.Collapsed;
        }
    }
}
