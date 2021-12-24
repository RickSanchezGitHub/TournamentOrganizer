using System.Windows;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TournamentCommands
{
    public class BackPlayersCommand : CommandBase
    {
        private TabItemTournamentsViewModel _viewModel;

        public BackPlayersCommand(TabItemTournamentsViewModel viewModel) : base()
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.VisibilityDataGridPlayers = Visibility.Collapsed;
            _viewModel.VisibilityDataGridTournaments = Visibility.Visible;
            _viewModel.VisibilityBackPlayersButton = Visibility.Collapsed;
        }
    }
}