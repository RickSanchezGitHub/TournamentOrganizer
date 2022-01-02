using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.BusinessLayer.Configuration;
using TournamentOrganizer.UI.ViewModels;

namespace TournamentOrganizer.UI.Commands
{
    public class EditGameCommand : CommandBase
    {
        private TabItemGameViewModel _viewModel;
         private IGameService _gameService;

        public EditGameCommand(TabItemGameViewModel viewModel, IGameService gameService) : base()
        {
            _viewModel = viewModel;
            _gameService = gameService;
        }
        public override void Execute(object parameter)
        {
            _viewModel.TextBoxAddGameNameText = _viewModel.SelectedGame.Name;
            _viewModel.IsEnabledButtonAdd = false;
            _viewModel.IsEnabledButtonCancel = true;
            _viewModel.IsEnabledButtonSave = true;
            _viewModel.StateDataGrid = false;
        }
    }
}