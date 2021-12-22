using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TournamentOrganizer.UI.Command;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TabItemPlayerCommands
{
    public class AddClickCommand : CommandBase
    {
        private TabItemPlayerViewModel _viewModel;

        public AddClickCommand(TabItemPlayerViewModel viewModel) : base()
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            _viewModel.TextBoxFirstNameText = null;
            _viewModel.TextBoxLastNameText = null;
            _viewModel.TextBoxNickNameText = null;
            _viewModel.TextBoxEmailText = null;
            _viewModel.DatePickerBirthdaySelectedDate = DateTime.Now;

            _viewModel.WidthGridAddPlayer = new GridLength(1, GridUnitType.Star);
            _viewModel.StateMainDataGrid = false;
            //ViewModel.SelectedPlayer = null;
            _viewModel.IsEnabledButtonAddSave = true;
            _viewModel.VisibilityButtonAddSave = Visibility.Visible;

        }
    }
}
