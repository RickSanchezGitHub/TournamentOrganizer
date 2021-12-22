using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.BusinessLayer.Configuration;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands
{
    public class SaveGameCommand : CommandBase
    {
        private TabItemGameViewModel _viewModel;
        // private GameService _gameService;

        public SaveGameCommand(TabItemGameViewModel viewModel) : base()
        {
            _viewModel = viewModel;
            // _gameService = _viewModel._gameService;
        }
        public override void Execute(object parameter)
        {
            _viewModel.GameService.UpdateGameName(_viewModel.TextBoxAddGameNameText, _viewModel.SelectedGame.Id);
            _viewModel.IsEnabledButtonAdd = true;
            _viewModel.IsEnabledButtonSave = false;
            _viewModel.StateDataGrid = true;
        }
    }
}