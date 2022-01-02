using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.BusinessLayer.Configuration;
using TournamentOrganizer.UI.ViewModels;

namespace TournamentOrganizer.UI.Commands
{
    public class CancelGameCommand : CommandBase
    {
        private TabItemGameViewModel _viewModel;

        public CancelGameCommand(TabItemGameViewModel viewModel) : base()
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            _viewModel.IsEnabledButtonAdd = true;
            _viewModel.IsEnabledButtonSave = false;
            _viewModel.IsEnabledButtonCancel = false;
            _viewModel.TextBoxAddGameNameText = string.Empty;
            _viewModel.StateDataGrid = true;
        }
    }
}
