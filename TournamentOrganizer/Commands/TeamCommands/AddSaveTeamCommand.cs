using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.BusinessLayer.Service.TeamService;
using TournamentOrganizer.UI.Command;
using TournamentOrganizer.UI.Validation;
using TournamentOrganizer.UI.Validation.TabItemTeamValidation;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TeamCommands
{
    public class AddSaveTeamCommand : CommandBase
    {
        private TabItemTeamViewModel _viewModel;
        private ITeamService _teamService;
        private TabItemTeamValidation _tabItemTeamValidation;

        public AddSaveTeamCommand(TabItemTeamViewModel viewModel, ITeamService teamService) : base()
        {
            _viewModel = viewModel;
            _teamService = teamService;
            _tabItemTeamValidation = new TabItemTeamValidation(viewModel);
        }

        public override void Execute(object parameter)
        {
            if(_tabItemTeamValidation.CheckIsEmptyOrWtiteSpaceInputData())
            {
                HelperExceptionMessage.HelperMessageBox("CheckIsEmptyOrWtiteSpaceInputData");
            }

            if (_tabItemTeamValidation.CheckValidInputData())
            {
                HelperExceptionMessage.HelperMessageBox("CheckValidInputData");
            }

            var teamModel = new TeamModel
            {
                Name = _viewModel.TextBoxName
            };

            _viewModel.VisibilityColumnAddTeam = Visibility.Collapsed;
            int idNewTeam = _teamService.Insert(teamModel);
            teamModel.Id = idNewTeam;
            _viewModel.Teams.Add(teamModel);
        }

    }
}
