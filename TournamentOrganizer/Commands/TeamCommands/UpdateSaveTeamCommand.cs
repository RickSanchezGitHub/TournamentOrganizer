using System.Windows;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service.TeamPlayerService;
using TournamentOrganizer.BusinessLayer.Service.TeamService;
using TournamentOrganizer.UI.Command;
using TournamentOrganizer.UI.Validation;
using TournamentOrganizer.UI.Validation.TabItemTeamValidation;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TeamCommands
{
    public class UpdateSaveTeamCommand : CommandBase
    {
        private readonly TabItemTeamViewModel _viewModel;
        private readonly ITeamService _teamService;
        private readonly ITeamPLayerService _teamPLayerService;
        private TabItemTeamValidation _tabItemTeamValidation;

        public UpdateSaveTeamCommand(TabItemTeamViewModel viewModel, ITeamService teamService, ITeamPLayerService teamPLayerService)
        {
            _viewModel = viewModel;
            _teamService = teamService;
            _teamPLayerService = teamPLayerService;
            _tabItemTeamValidation = new TabItemTeamValidation(viewModel);

        }
        public override void Execute(object parameter)
        {
            if (_tabItemTeamValidation.CheckIsEmptyOrWtiteSpaceInputData())
            {
                HelperExceptionMessage.HelperMessageBox("CheckIsEmptyOrWtiteSpaceInputData");
            }

            if (_tabItemTeamValidation.CheckValidInputData())
            {
                HelperExceptionMessage.HelperMessageBox("CheckValidInputData");
            }

            try
            {
                var teamModel = new TeamModel
                {
                    Name = _viewModel.TextBoxName
                };
                _teamService.Update(_viewModel.SelectedTeam.Id, teamModel);

                foreach (var player in _viewModel.PlayersToAddInTeam)
                {
                    var teamPlayerModel = new TeamPlayerModel
                    {
                        TeamId = _viewModel.SelectedTeam.Id,
                        PlayerId = player.Id
                    };
                    _teamPLayerService.Insert(teamPlayerModel);
                    _viewModel.SelectedTeam.Players.Add(player);
                }
            }
            catch
            {
                HelperExceptionMessage.HelperMessageBox("Help");
            }

            _viewModel.PlayersToAddInTeam.Clear();
            _viewModel.AvailablePlayersToAddInTeam.Clear();
            _viewModel.SelectedTeam.Name = _viewModel.TextBoxName;
            _viewModel.VisibilityColumnAddTeam = Visibility.Collapsed;
            _viewModel.VisibilityColumnUpdateTeam = Visibility.Collapsed;
            _viewModel.VisibilitySaveButton = Visibility.Collapsed;
        }
    }
}
