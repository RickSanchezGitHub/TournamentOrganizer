using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.BusinessLayer.Configuration;
using TournamentOrganizer.UI.ViewModels;

namespace TournamentOrganizer.UI.Commands
{
    public class SaveGameCommand : CommandBase
    {
        private TabItemGameViewModel _viewModel;
        private IGameService _gameService;

        public SaveGameCommand(TabItemGameViewModel viewModel, IGameService gameService) : base()
        {
            _viewModel = viewModel;
            _gameService = gameService;
        }
        public override void Execute(object parameter)
        {
            _gameService.UpdateGameName(_viewModel.TextBoxAddGameNameText, _viewModel.SelectedGame.Id);
            _viewModel.SelectedGame.Name = _viewModel.TextBoxAddGameNameText;
            _viewModel.TextBoxAddGameNameText = string.Empty;
            _viewModel.IsEnabledButtonAdd = true;
            _viewModel.IsEnabledButtonSave = false;
            _viewModel.StateDataGrid = true;
        }
    }
}