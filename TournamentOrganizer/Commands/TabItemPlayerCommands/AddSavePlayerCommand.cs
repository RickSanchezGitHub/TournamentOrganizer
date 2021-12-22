﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TournamentOrganizer.BusinessLayer.Configuration;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.UI.Command;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands
{
    public class AddSavePlayerCommand : CommandBase
    {
        private TabItemPlayerViewModel _viewModel;

        public AddSavePlayerCommand(TabItemPlayerViewModel viewModel) : base()
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            var playerModel = new PlayerModel
            {
                FirstName = _viewModel.TextBoxFirstNameText,
                LastName = _viewModel.TextBoxLastNameText,
                NickName = _viewModel.TextBoxNickNameText,
                Email = _viewModel.TextBoxEmailText,
                Birthday = _viewModel.DatePickerBirthdaySelectedDate
            };
            int idNewPlayer = _viewModel.PlayerService.InsertPlayer(playerModel);
            playerModel.Id = idNewPlayer;
            _viewModel.Players.Add(playerModel);


            _viewModel.WidthGridAddPlayer = new GridLength(0, GridUnitType.Star);
            _viewModel.StateMainDataGrid = true;

            _viewModel.IsEnabledButtonAddSave = false;
            _viewModel.VisibilityButtonAddSave = Visibility.Hidden;

        }
    }
}