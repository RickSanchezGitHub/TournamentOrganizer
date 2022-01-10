using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.GridOfTournamentsCommands
{
    public class BackFromRedistributeCommand : CommandBase
    {
        private TabItemGridOfTournamentsViewModel _viewModel;
        public BackFromRedistributeCommand(TabItemGridOfTournamentsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.ParticipantsForRedistribution.Clear();
            _viewModel.VisibilityStackPanelMatchResolve = Visibility.Collapsed;
            _viewModel.VisibilityDataGridShowTournamentParticipants = Visibility.Collapsed;
            _viewModel.VisibilityStackPanelMatchResolve = Visibility.Collapsed;
            _viewModel.VisibilityStackPanelRedistributeParticipants = Visibility.Collapsed;
            _viewModel.IsEnabledButtonShowParticipantsResultsAndRedistribute = true;
        }
    }
}
