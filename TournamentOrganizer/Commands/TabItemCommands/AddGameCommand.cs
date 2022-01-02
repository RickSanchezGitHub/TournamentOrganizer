using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TournamentOrganizer.BusinessLayer.Configuration;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.UI.ViewModels;

namespace TournamentOrganizer.UI.Commands
{
    public class AddGameCommand : CommandBase
    {
        private TabItemGameViewModel _viewModel;
        private IGameService _gameService;

        public AddGameCommand(TabItemGameViewModel viewModel, IGameService gameService) : base()
        {
            _viewModel = viewModel;
            _gameService = gameService;
        }

        public override void Execute(object parameter)
        {
            bool canExecute = Validation.TextBoxValidation(_viewModel.TextBoxAddGameNameText);
            if (!canExecute)
            {
                MessageBox.Show("Введите корректное название игры", "Выйди и зайди нормально", MessageBoxButton.OK);
            }
            else
            {
                var id = _gameService.InsertGame(_viewModel.TextBoxAddGameNameText);
                _viewModel.Games.Add(new GameModel { Id = id, Name = _viewModel.TextBoxAddGameNameText });
                _viewModel.TextBoxAddGameNameText = string.Empty;

            }
        }

    }
}