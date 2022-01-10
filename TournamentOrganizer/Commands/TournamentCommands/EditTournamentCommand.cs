using System.Windows;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TournamentCommands
{
    public class EditTournamentCommand : CommandBase
    {
        private readonly TabItemTournamentsViewModel _viewModel;

        public EditTournamentCommand(TabItemTournamentsViewModel viewModel) : base()
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            _viewModel.TextBoxName = _viewModel.SelectedTournament.Name;
            _viewModel.DatePickerStartDate = _viewModel.SelectedTournament.StartDate;
            _viewModel.DatePickerCloseDate = _viewModel.SelectedTournament.CloseDate;
            _viewModel.SelectedGame = _viewModel.SelectedTournament.Game;
            _viewModel.VisibilityColumn = Visibility.Visible;
            _viewModel.VisibilitySaveButton = Visibility.Collapsed;
            _viewModel.VisibilityUpdateButton = Visibility.Visible;
            _viewModel.VisibilityCheckBoxSelectedTournamentType = Visibility.Collapsed;
            _viewModel.VisibilityButtonParticipants = Visibility.Visible;
        }
    }
}
