using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.BusinessLayer.Configuration;
using TournamentOrganizer.UI.ViewModels;

namespace TournamentOrganizer.UI.Commands
{
    public class DeleteGameCommand : CommandBase
    {
        private TabItemGameViewModel _viewModel;
        private IGameService _gameService;

        public DeleteGameCommand(TabItemGameViewModel viewModel, IGameService gameService) : base()
        {
            _viewModel = viewModel;
            _gameService = gameService;
        }
        public override void Execute(object parameter)
        {
            _gameService.DeleteGame(_viewModel.SelectedGame.Id);
            _viewModel.Games.Remove(_viewModel.SelectedGame);

        }
    }
}
