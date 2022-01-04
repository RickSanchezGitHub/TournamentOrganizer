using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TournamentOrganizer.BusinessLayer.Configuration;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.Command;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands
{
    public class AddSavePlayerCommand : CommandBase
    {
        private TabItemPlayerViewModel _viewModel;

        private readonly IPlayerService _playerService;

        public AddSavePlayerCommand(TabItemPlayerViewModel viewModel, IPlayerService playerService) : base()
        {
            _viewModel = viewModel;
            _playerService = playerService;
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


            var playerModel = new PlayerModel

            {
                FirstName = _viewModel.TextBoxFirstNameText,
                LastName = _viewModel.TextBoxLastNameText,
                NickName = _viewModel.TextBoxNickNameText,
                Email = _viewModel.TextBoxEmailText,
                Birthday = _viewModel.DatePickerBirthdaySelectedDate
            };

            int idNewPlayer = _playerService.InsertPlayer(playerModel);
            playerModel.Id = idNewPlayer;
            _viewModel.Players.Add(playerModel);


            _viewModel.WidthGridAddPlayer = new GridLength(0, GridUnitType.Star);
            _viewModel.StateMainDataGrid = true;

            _viewModel.IsEnabledButtonAddSave = false;
            _viewModel.VisibilityButtonAddSave = Visibility.Hidden;
            _viewModel.IsEnabledButtonAdd = true;

        }
    }
}