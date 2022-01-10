using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.BusinessLayer.Service.TeamService;
using TournamentOrganizer.UI.Command;
using TournamentOrganizer.UI.Validation.TabItemTeamValidation;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TeamCommands
{
    public class UpdateTeamCommand : CommandBase
    {
        private readonly TabItemTeamViewModel _viewModel;
        private readonly ITeamService _teamService;
        private TabItemTeamValidation _tabItemTeamValidation;

        public UpdateTeamCommand(TabItemTeamViewModel viewModel, ITeamService teamService)
        {
            _viewModel = viewModel;
            _teamService = teamService;
            _tabItemTeamValidation = new TabItemTeamValidation(viewModel);
        }

        public override void Execute(object parameter)
        {
            if (_tabItemTeamValidation.CheckIsEmptySelectedTeam() == false)
            {
                MessageBox.Show("Выберите команду",
                                "Ошибка ",
                                MessageBoxButton.OK);
                return;
            }

            var players = _teamService.GetAvailablePlayersToAdd(_viewModel.SelectedTeam.Id);
            foreach (var item in players)
            {
                _viewModel.AvailablePlayersToAddInTeam.Add(item);
            }

            _viewModel.VisibilityColumnAddTeam = Visibility.Collapsed;
            _viewModel.VisibilityColumnUpdateTeam = Visibility.Visible;
            _viewModel.VisibilitySaveButton = Visibility.Visible;
            _viewModel.TextBoxName = _viewModel.SelectedTeam.Name;
        }
    }
}
