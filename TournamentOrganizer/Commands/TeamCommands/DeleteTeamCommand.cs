using System.Windows;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.BusinessLayer.Service.TeamService;
using TournamentOrganizer.UI.Command;
using TournamentOrganizer.UI.Validation;
using TournamentOrganizer.UI.Validation.TabItemTeamValidation;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TeamCommands
{
    public class DeleteTeamCommand : CommandBase
    {
        private readonly TabItemTeamViewModel _viewModel;

        private readonly ITeamService _teamService;
        private TabItemTeamValidation _tabItemTeamValidation;

        public DeleteTeamCommand(TabItemTeamViewModel viewModel, ITeamService teamService)
        {
            _viewModel = viewModel;
            _teamService = teamService;
            _tabItemTeamValidation = new TabItemTeamValidation(viewModel);
        }

        public override void Execute(object parameter)
        {
            if(_tabItemTeamValidation.CheckIsEmptySelectedTeam() == false)
            {
                HelperExceptionMessage.HelperMessageBox("CheckIsEmptySelectedTeam");
            }
            _teamService.Delete(_viewModel.SelectedTeam.Id);
            _viewModel.Teams.Remove(_viewModel.SelectedTeam);
        }
    }
}
