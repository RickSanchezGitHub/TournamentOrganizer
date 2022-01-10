using System.Windows;
using System.Windows.Controls;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.GridOfTournamentsCommands
{
    public class ResolveMatchCommand : CommandBase
    {
        private TabItemGridOfTournamentsViewModel _viewModel;

        public ResolveMatchCommand(TabItemGridOfTournamentsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            var button = (Button)parameter;
            var data = button.DataContext;
            _viewModel.SelctedMatchInTreeView = (MatchModel)data;
            _viewModel.VisibilityStackPanelMatchResolve = Visibility.Visible;
            _viewModel.VisibilityDataGridShowTournamentParticipants = Visibility.Collapsed;
        }
    }
}
