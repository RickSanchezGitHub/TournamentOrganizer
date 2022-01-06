using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TournamentOrganizer.BusinessLayer.Configuration;
using TournamentOrganizer.UI.Command;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands
{
    public class BackFromAddCommand : CommandBase
    {
       
        private TabItemPlayerViewModel _viewModel;

        public BackFromAddCommand(TabItemPlayerViewModel viewModel) : base()
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            _viewModel.WidthGridAddPlayer = new GridLength((int)TabItemPlayerViewModel.WidthGridColumn.ColumnHidden, GridUnitType.Star);
            _viewModel.StateMainDataGrid = true;
            _viewModel.VisibilityButtonAddSave = Visibility.Hidden;
            _viewModel.VisibilityButtonEditSave = Visibility.Hidden;
            _viewModel.IsEnabledButtonAddSave = false;
            _viewModel.IsEnabledButtonEditSave = false;
            _viewModel.IsEnabledButtonAdd = true;
        }
    }
}
