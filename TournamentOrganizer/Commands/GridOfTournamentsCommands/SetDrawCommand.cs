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
            var players = _viewModel.SelctedMatchInTreeView.Participants;
            foreach (var item in players)
            {
                _viewModel.SelctedMatchInTreeView.ResolveDraw(_viewModel.SelectedTournament, item);
            }
            _viewModel.VisibilityStackPanelMatchResolve = Visibility.Hidden;
            _viewModel.SelctedPlayerInComboBox = null;
        }
    }
}
