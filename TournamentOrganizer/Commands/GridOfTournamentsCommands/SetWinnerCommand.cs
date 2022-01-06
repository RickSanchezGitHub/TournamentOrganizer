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
            MessageBoxResult userAnswer = MessageBox.Show($"Установить победителем {_viewModel.SelctedPlayerInComboBox.NickName} ?", "Подтверждение",
                        MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (userAnswer == MessageBoxResult.No)
            {
                return;
            }
            _viewModel.SelctedMatchInTreeView.ResolveWinner(_viewModel.SelectedTournament, _viewModel.SelctedPlayerInComboBox);
            _viewModel.VisibilityStackPanelMatchResolve = Visibility.Collapsed;
            _viewModel.SelectedButton.Content = "Матч разрешён";
            _viewModel.SelectedButton.IsEnabled = false;
        }
    }
}
