using System.Windows;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TournamentCommands
{
    public class BackTournamentCommand : CommandBase
    {
        private TabItemTournamentsViewModel _viewModel;

        public BackTournamentCommand(TabItemTournamentsViewModel viewModel) : base()
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            
            _viewModel.VisibilityColumn = Visibility.Collapsed;
        }
    }
}
