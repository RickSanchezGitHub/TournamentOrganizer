using System;
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
            _viewModel.VisibilityCheckBoxSelectedTournamentType = Visibility.Visible;
            _viewModel.VisibilityButtonParticipants = Visibility.Collapsed;
            _viewModel.TextBoxName = null;
            _viewModel.DatePickerStartDate = DateTime.Today;
            _viewModel.DatePickerCloseDate = DateTime.Today;
        }
    }
}
