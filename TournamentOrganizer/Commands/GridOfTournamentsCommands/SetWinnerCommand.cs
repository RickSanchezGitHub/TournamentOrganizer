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
            if (_viewModel.SelctedPlayerInComboBox == null)
            {
                MessageBox.Show("Необходимо выбрать победителя");
                return;
            }
            _viewModel.SelctedMatchInTreeView.ResolveWinner(_viewModel.SelectedTournament, _viewModel.SelctedPlayerInComboBox);
            _viewModel.VisibilityStackPanelMatchResolve = Visibility.Hidden;
        }
    }
}
