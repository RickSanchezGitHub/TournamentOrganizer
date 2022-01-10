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
    public class BackFromInfoCommand : CommandBase
    {
        
        private TabItemPlayerViewModel _viewModel;

        public BackFromInfoCommand(TabItemPlayerViewModel viewModel) : base()
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            _viewModel.WidthGridPlayerInfo = new GridLength((int)TabItemPlayerViewModel.WidthGridColumn.ColumnHidden, GridUnitType.Star);
            _viewModel.StateMainDataGrid = true;
            _viewModel.IsEnabledButtonAdd = true;
        }
    }
}
