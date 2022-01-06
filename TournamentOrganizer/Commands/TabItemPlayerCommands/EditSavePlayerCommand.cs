using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TournamentOrganizer.BusinessLayer.Configuration;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.Command;
using TournamentOrganizer.UI.Commands.TabItemPlayerCommands;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands
{
    public class EditSavePlayerCommand : CommandBase
    {
        
        private TabItemPlayerViewModel _viewModel;

        private readonly IPlayerService _playerService;

        private ValidationTabItemPlayer _validationTabItemPlayer;

        public EditSavePlayerCommand(TabItemPlayerViewModel viewModel, IPlayerService playerService) : base()
        {
            _viewModel = viewModel;
            _playerService = playerService;
            _validationTabItemPlayer = new ValidationTabItemPlayer(viewModel);
        }

        public override void Execute(object parameter)
        {
            if (_validationTabItemPlayer.CheckIsEmptyOrWhiteSpaceInputData())
            {
                MessageBox.Show("Заполните все поля");
                return;
            }


            if (_validationTabItemPlayer.CheckIsValidInputData())
            {
                MessageBox.Show("Имя и Фамилия не должны содержать 1234567890!@#$%^&*()_+= и пробелов");
                return;
            }

            _viewModel.SelectedPlayer.FirstName = _viewModel.TextBoxFirstNameText;
            _viewModel.SelectedPlayer.LastName = _viewModel.TextBoxLastNameText;
            _viewModel.SelectedPlayer.NickName = _viewModel.TextBoxNickNameText;
            _viewModel.SelectedPlayer.Email = _viewModel.TextBoxEmailText;
            _viewModel.SelectedPlayer.Birthday = _viewModel.DatePickerBirthdaySelectedDate;
            _playerService.PlayerUpdate(_viewModel.SelectedPlayer.Id, _viewModel.SelectedPlayer);
            _viewModel.IsEnabledButtonEditSave = false;
            _viewModel.VisibilityButtonEditSave = Visibility.Hidden;

            _viewModel.WidthGridAddPlayer = new GridLength((int)TabItemPlayerViewModel.WidthGridColumn.ColumnHidden, GridUnitType.Star);
            _viewModel.StateMainDataGrid = true;
            _viewModel.IsEnabledButtonAdd = true;

            
        }
    }
}