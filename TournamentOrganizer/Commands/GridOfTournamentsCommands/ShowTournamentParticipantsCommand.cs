using System.Windows;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.GridOfTournamentsCommands
{
    public class ShowTournamentParticipantsCommand : CommandBase
    {
        private readonly TabItemGridOfTournamentsViewModel _viewModel;
        private readonly IResultTournamentPlayerService _resultTournamentPlayerService;
        private readonly IResultTournamentTeamService _resultTournamentTeamService;
        public ShowTournamentParticipantsCommand(TabItemGridOfTournamentsViewModel viewModel, IResultTournamentPlayerService resultTournamentPlayerService,
            IResultTournamentTeamService resultTournamentTeamService)
        {
            _viewModel = viewModel;
            _resultTournamentPlayerService = resultTournamentPlayerService;
            _resultTournamentTeamService = resultTournamentTeamService;
        }

        public override void Execute(object parameter)
        {
            _viewModel.VisibilityStackPanelMatchResolve = Visibility.Collapsed;
            _viewModel.VisibilityStackPanelMatchResolve = Visibility.Collapsed;
            _viewModel.VisibilityStackPanelRedistributeParticipants = Visibility.Collapsed;
            if (_viewModel.ShowParticipantsTournamentResult == "Показать участников турнира")
            {
                _viewModel.VisibilityDataGridShowTournamentParticipants = Visibility.Visible;
                _viewModel.ShowParticipantsTournamentResult = "Скрыть участников турнира";
                HelperForLoadAndSorted.SortResultInTournament(_viewModel.SelectedTournament, _resultTournamentPlayerService, _resultTournamentTeamService);
            }
            else
            {
                _viewModel.VisibilityDataGridShowTournamentParticipants = Visibility.Collapsed;
                _viewModel.ShowParticipantsTournamentResult = "Показать участников турнира";
                return;
            }

        }
    }
}
