
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands
{
    public class SetWinnerCommand : CommandBase
    {
        private readonly TabItemGridOfTournamentsViewModel _viewModel;
        private readonly IResultTournamentPlayerService _resultTournamentPlayerService;
        private readonly IResultTournamentTeamService _resultTournamentTeamService;
        public SetWinnerCommand(TabItemGridOfTournamentsViewModel viewModel, IResultTournamentPlayerService resultTournamentPlayerService,
            IResultTournamentTeamService resultTournamentTeamService)
        {
            _viewModel = viewModel;
            _resultTournamentPlayerService = resultTournamentPlayerService;
            _resultTournamentTeamService = resultTournamentTeamService;
        }

        public override void Execute(object parameter)
        {
            if (_viewModel.SelectedResult == null)
            {
                MessageBox.Show("Необходимо выбрать победителя");
                return;
            }
            MessageBoxResult userAnswer = MessageBox.Show($"Установить победителем ?", "Подтверждение",
                        MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (userAnswer == MessageBoxResult.No)
            {
                return;
            }

            var looser = _viewModel.SelctedMatchInTreeView.ParticipantsResults.First(item => item != _viewModel.SelectedResult);
            _viewModel.SelectedResult.Tournament = _viewModel.SelectedTournament;
            looser.Tournament = _viewModel.SelectedTournament;
            int numberRound = _viewModel.SelctedMatchInTreeView.ResolveWinner(_viewModel.SelectedTournament, _viewModel.SelectedResult);
            if (_viewModel.SelectedTournament.OnlyForTeams)
            {
                _resultTournamentTeamService.SetTeamResultInRoundOfTournament(_viewModel.SelectedResult as ResultTournamentTeamModel, 2);

                _resultTournamentTeamService.SetTeamResultInRoundOfTournament(looser as ResultTournamentTeamModel, 0);
            }
            else
            {
                _resultTournamentPlayerService.SetPlayerResultInRoundOfTournament(2, _viewModel.SelectedResult as ResultTournamentPlayerModel);

                _resultTournamentPlayerService.SetPlayerResultInRoundOfTournament(0, looser as ResultTournamentPlayerModel);
            }
            _viewModel.VisibilityStackPanelMatchResolve = Visibility.Collapsed;

        }
    }
}
