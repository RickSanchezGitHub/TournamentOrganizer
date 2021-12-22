using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.BusinessLayer.Configuration;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands
{
    public class DeleteGameCommand : CommandBase
    {
        private TabItemGameViewModel _viewModel;
       // private GameService _gameService;

        public DeleteGameCommand(TabItemGameViewModel viewModel) : base()
        {
            _viewModel = viewModel;
           // _gameService = _viewModel._gameService;
        }
        public override void Execute(object parameter)
        {
            _viewModel._gameService.DeleteGame(_viewModel.SelectedGame.Id);
            _viewModel.Games.Remove(_viewModel.SelectedGame);

        }
    }
}
