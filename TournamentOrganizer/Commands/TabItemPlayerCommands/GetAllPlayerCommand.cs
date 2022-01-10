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
            foreach (var item in players)
            {
                _viewModel.Players.Add(item);
            }
        }
    }
}
