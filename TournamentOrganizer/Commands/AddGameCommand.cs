using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.BusinessLayer.Configuration;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands
{
    public class AddGameCommand : CommandBase
    {
        private TabItemGameViewModel _viewModel;
       // private GameService _gameService;

        public AddGameCommand(TabItemGameViewModel viewModel) : base()
        {
            _viewModel = viewModel;
         //   _gameService = _viewModel._gameService;
        }
   
        public override void Execute(object parameter)
        {
            _viewModel.GameService.InsertGame(_viewModel.TextBoxAddGameNameText);
            _viewModel.Games.Add(new GameModel { Name = _viewModel.TextBoxAddGameNameText } );

        }
    }
}