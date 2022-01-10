using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.Command;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TabItemPlayerCommands
{
    public class LoadPlayersCommand : CommandBase
    {
        private TabItemPlayerViewModel _viewModel;

        private readonly IPlayerService _playerService;

        private ValidationTabItemPlayer _validationTabItemPlayer;

        public LoadPlayersCommand(TabItemPlayerViewModel viewModel, IPlayerService playerService) : base()
        {
            _viewModel = viewModel;
            _playerService = playerService;
        }

        public override void Execute(object parameter)
        {
            foreach (var item in _playerService.GetAll())
                _viewModel.Players.Add(item);
        }

    }
}
