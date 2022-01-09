using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service.TeamPlayerService;
using TournamentOrganizer.BusinessLayer.Service.TeamService;
using TournamentOrganizer.UI.Command;
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
                MessageBox.Show("Заполните поле",
                                "Ошибка ",
                                MessageBoxButton.OK);
                return;
            }
            if (_tabItemTeamValidation.CheckValidInputData())
            {
                MessageBox.Show("Название не должно содержать никаких символов, пробелов и не должно превышать 25 символов",
                                "Ошибка ",
                                MessageBoxButton.OK);
                return;
            }

            var teamModel = new TeamModel
            {
                Name = _viewModel.TextBoxName
            };         
            _teamService.Update(_viewModel.SelectedTeam.Id, teamModel);

            foreach(var player in _viewModel.PlayersToAddInTeam)
            {
                var teamPlayerModel = new TeamPlayerModel
                {
                    TeamId = _viewModel.SelectedTeam.Id,
                    PlayerId = player.Id
                };
                _teamPLayerService.Insert(teamPlayerModel);
                _viewModel.SelectedTeam.Players.Add(player);
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
