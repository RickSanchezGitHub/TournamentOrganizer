using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service.PlayerService;
using TournamentOrganizer.UI.Command;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TabItemPlayerCommands
{
    public class GetAllPlayerCommand : CommandBase
    {
        private readonly TabItemTeamViewModel _viewModel;
        private readonly IPlayerService _playerService;
        public GetAllPlayerCommand(TabItemTeamViewModel viewModel, IPlayerService playerService)
        {
            _viewModel = viewModel;
            _playerService = playerService;
        }
        public override void Execute(object parameter)
        {
            var players = _playerService.GetAll();
            _viewModel.Players = new ObservableCollection<PlayerModel>(players);
        }
    }
}
