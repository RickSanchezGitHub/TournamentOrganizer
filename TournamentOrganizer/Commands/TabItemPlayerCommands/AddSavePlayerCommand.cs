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
using TournamentOrganizer.UI.Commands.TabItemPlayerCommands;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands
{
    public class AddSavePlayerCommand : CommandBase
    {
       
        private TabItemPlayerViewModel _viewModel;

        private readonly IPlayerService _playerService;

        private ValidationTabItemPlayer _validationTabItemPlayer;

        public AddSavePlayerCommand(TabItemPlayerViewModel viewModel, IPlayerService playerService) : base()
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
                MessageBox.Show("Имя и Фамилия не должны содержать 1234567890!@#$%^&*()_+= и пробелов и название не должно превышать 25 символов");
                return;
            }

            if (Validation.BirthdayValidation(_viewModel.DatePickerBirthdaySelectedDate))
            {
                MessageBox.Show("Игроку должно быть больше 14 лет");
                return;
            }


            PlayerModel playerModel = new PlayerModel
            {
                FirstName = _viewModel.TextBoxFirstNameText,
                LastName = _viewModel.TextBoxLastNameText,
                Name = _viewModel.TextBoxNameText,
                Email = _viewModel.TextBoxEmailText,
                Birthday = _viewModel.DatePickerBirthdaySelectedDate
            };

            int idNewPlayer = _playerService.InsertPlayer(playerModel);
            playerModel.Id = idNewPlayer;
            _viewModel.Players.Add(playerModel);


            _viewModel.WidthGridAddPlayer = new GridLength((int)TabItemPlayerViewModel.WidthGridColumn.ColumnHidden, GridUnitType.Star);
            _viewModel.StateMainDataGrid = true;

            _viewModel.IsEnabledButtonAddSave = false;
            _viewModel.VisibilityButtonAddSave = Visibility.Hidden;
            _viewModel.IsEnabledButtonAdd = true;

        }
    }
}