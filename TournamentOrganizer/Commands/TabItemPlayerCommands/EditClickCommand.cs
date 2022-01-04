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
            bool canExecute = Validation.TextBoxValidationIsEmptyOrWhiteSpace(_viewModel.TextBoxFirstNameText) &&
                Validation.TextBoxValidationIsEmptyOrWhiteSpace(_viewModel.TextBoxLastNameText) &&
                Validation.TextBoxValidationIsEmptyOrWhiteSpace(_viewModel.TextBoxEmailText) &&
                Validation.TextBoxValidationIsEmptyOrWhiteSpace(_viewModel.TextBoxNickNameText);
            if (!canExecute)
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            canExecute = Validation.TextBoxValidation(_viewModel.TextBoxFirstNameText) &&
                Validation.TextBoxValidation(_viewModel.TextBoxLastNameText);
            if (!canExecute)
            {
                MessageBox.Show("Имя и Фамилия не должны содержать 1234567890!@#$%^&*()_+= и пробелов");
                return;
            }

            _viewModel.IsEnabledButtonEditSave = true;
            _viewModel.VisibilityButtonEditSave = Visibility.Visible;

            _viewModel.WidthGridAddPlayer = new GridLength(1, GridUnitType.Star);
            _viewModel.TextBoxFirstNameText = _viewModel.SelectedDeletePlayer.FirstName;
            _viewModel.TextBoxLastNameText = _viewModel.SelectedDeletePlayer.LastName;
            _viewModel.TextBoxNickNameText = _viewModel.SelectedDeletePlayer.NickName;
            _viewModel.TextBoxEmailText = _viewModel.SelectedDeletePlayer.Email;
            _viewModel.DatePickerBirthdaySelectedDate = _viewModel.SelectedDeletePlayer.Birthday;

            _viewModel.StateMainDataGrid = false;
            _viewModel.IsEnabledButtonAdd = false;

        }
    }
}