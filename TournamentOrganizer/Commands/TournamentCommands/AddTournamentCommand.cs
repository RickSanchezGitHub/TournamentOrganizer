using System.Windows;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TournamentCommands
{
    public class AddTournamentCommand : CommandBase
    {
        private TabItemTournamentsViewModel _viewModel;

        public AddTournamentCommand(TabItemTournamentsViewModel viewModel) : base()
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            _viewModel.VisibilityColumn = Visibility.Visible;
            _viewModel.VisibilitySaveButton = Visibility.Visible;
            _viewModel.VisibilityUpdateButton = Visibility.Collapsed;
            _viewModel.TextBoxName = "";
            _viewModel.DatePickerStartDate = null;
            _viewModel.DatePickerCloseDate = null;
            _viewModel.SelectedGame = null;
        }
    }
}
