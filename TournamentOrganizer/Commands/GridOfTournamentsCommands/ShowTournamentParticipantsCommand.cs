using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.GridOfTournamentsCommands
{
    public class ShowTournamentParticipantsCommand : CommandBase
    {
        private TabItemGridOfTournamentsViewModel _viewModel;
        private ResultTournamentPlayerService _resultTournamentPlayerService;
        private ResultTournamentTeamService _resultTournamentTeamService;
        public ShowTournamentParticipantsCommand(TabItemGridOfTournamentsViewModel viewModel)
        {
            _viewModel = viewModel;
            _resultTournamentPlayerService = new();
            _resultTournamentTeamService = new();
        }

        public override void Execute(object parameter)
        {
            _viewModel.ParticipantTournamentResults.Clear();
            _viewModel.VisibilityStackPanelMatchResolve = Visibility.Collapsed;
            _viewModel.VisibilityDataGridShowTournamentParticipants = Visibility.Visible;
            _viewModel.VisibilityStackPanelMatchResolve = Visibility.Collapsed;
            _viewModel.VisibilityStackPanelRedistributeParticipants = Visibility.Collapsed;
            if (_viewModel.ShowParticipantsTournamentResult == "Показать участников турнира")
            {
                _viewModel.VisibilityDataGridShowTournamentParticipants = System.Windows.Visibility.Visible;
                _viewModel.ShowParticipantsTournamentResult = "Скрыть участников турнира";
            }
            else
            {
                _viewModel.VisibilityDataGridShowTournamentParticipants = System.Windows.Visibility.Collapsed;
                _viewModel.ShowParticipantsTournamentResult = "Показать участников турнира";
                return;
            }

            SortedResults.SortResultInTournament(_viewModel.SelectedTournament, _resultTournamentPlayerService, _resultTournamentTeamService);

        }
    }
}
