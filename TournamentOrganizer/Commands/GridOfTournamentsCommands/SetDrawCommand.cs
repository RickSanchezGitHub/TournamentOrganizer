using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands
{
    public class SetDrawCommand : CommandBase
    {
        private TabItemGridOfTournamentsViewModel _viewModel;
        public SetDrawCommand(TabItemGridOfTournamentsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            MessageBoxResult userAnswer = MessageBox.Show($"Установить ничью?", "Подтверждение",
                        MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (userAnswer == MessageBoxResult.No)
            {
                return;
            }
            var players = _viewModel.SelctedMatchInTreeView.Participants;
            foreach (var item in players)
            {
                _viewModel.SelctedMatchInTreeView.ResolveDraw(_viewModel.SelectedTournament, item);
            }
            _viewModel.VisibilityStackPanelMatchResolve = Visibility.Collapsed;
            _viewModel.SelctedPlayerInComboBox = null;
            _viewModel.SelectedButton.Content = "Матч разрешён";
            _viewModel.SelectedButton.IsEnabled = false;
        }
    }
}
