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
    public class EditClickCommand : CommandBase
    {
       
        private TabItemPlayerViewModel _viewModel;

        public EditClickCommand(TabItemPlayerViewModel viewModel) : base()
        {
            _viewModel = viewModel;
        }
        
        public override void Execute(object parameter)
        {
           

            _viewModel.IsEnabledButtonEditSave = true;
            _viewModel.VisibilityButtonEditSave = Visibility.Visible;

            _viewModel.WidthGridAddPlayer = new GridLength((int)TabItemPlayerViewModel.WidthGridColumn.ColumnVisible, GridUnitType.Star);
            _viewModel.TextBoxFirstNameText = _viewModel.SelectedPlayer.FirstName;
            _viewModel.TextBoxLastNameText = _viewModel.SelectedPlayer.LastName;
            _viewModel.TextBoxNameText = _viewModel.SelectedPlayer.Name;
            _viewModel.TextBoxEmailText = _viewModel.SelectedPlayer.Email;
            _viewModel.DatePickerBirthdaySelectedDate = _viewModel.SelectedPlayer.Birthday;

            _viewModel.StateMainDataGrid = false;
            _viewModel.IsEnabledButtonAdd = false;

        }
    }
}