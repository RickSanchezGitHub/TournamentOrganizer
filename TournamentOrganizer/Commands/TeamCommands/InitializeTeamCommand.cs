using TournamentOrganizer.BusinessLayer.Service.PlayerService;
using TournamentOrganizer.BusinessLayer.Service.TeamService;
using TournamentOrganizer.UI.Command;
using TournamentOrganizer.UI.Validation;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TeamCommands
{
    public class InitializeTeamCommand : CommandBase
    {
        private readonly TabItemTeamViewModel _viewModel;
        private readonly ITeamService _teamService;
        private readonly IPlayerService _playerService;

        public InitializeTeamCommand(TabItemTeamViewModel viewModel, ITeamService teamService, IPlayerService playerService)
        {
            _viewModel = viewModel;
            _teamService = teamService;
            _playerService = playerService;
        }

        public override void Execute(object parameter)
        {
            try
            {
                var teams = _teamService.GetAll();
                foreach (var item in teams)
                {
                    _viewModel.Teams.Add(item);
                }

                var players = _playerService.GetAll();
                foreach (var item in players)
                {
                    _viewModel.Players.Add(item);
                }
        }
            catch
            {
                HelperExceptionMessage.HelperMessageBox("Help");
            }
}
    }
}
