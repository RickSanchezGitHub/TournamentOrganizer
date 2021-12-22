﻿using System;
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
    public class EditSavePlayerCommand : CommandBase
    {
        private TabItemPlayerViewModel _viewModel;

        public EditSavePlayerCommand(TabItemPlayerViewModel viewModel) : base()
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            _viewModel.SelectedDeletePlayer.FirstName = _viewModel.TextBoxFirstNameText;
            _viewModel.SelectedDeletePlayer.LastName = _viewModel.TextBoxLastNameText;
            _viewModel.SelectedDeletePlayer.NickName = _viewModel.TextBoxNickNameText;
            _viewModel.SelectedDeletePlayer.Email = _viewModel.TextBoxEmailText;
            _viewModel.SelectedDeletePlayer.Birthday = _viewModel.DatePickerBirthdaySelectedDate;
            _viewModel.PlayerService.PlayerUpdate(_viewModel.SelectedDeletePlayer.Id, _viewModel.SelectedDeletePlayer);
            _viewModel.IsEnabledButtonEditSave = false;
            _viewModel.VisibilityButtonEditSave = Visibility.Hidden;

            _viewModel.WidthGridAddPlayer = new GridLength(0, GridUnitType.Star);
            _viewModel.StateMainDataGrid = true;

        }
    }
}