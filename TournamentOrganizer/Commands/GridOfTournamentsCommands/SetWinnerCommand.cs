
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands
{
    public class SetWinnerCommand : CommandBase
    {
        private TabItemGridOfTournamentsViewModel _viewModel;
        private readonly ResultTournamentPlayerService _resultTournamentPlayerService;
        private readonly ResultTournamentTeamService _resultTournamentTeamService;
        public SetWinnerCommand(TabItemGridOfTournamentsViewModel viewModel)
        {
            _viewModel = viewModel;
            _resultTournamentPlayerService = new();
            _resultTournamentTeamService = new();
        }

        public override void Execute(object parameter)
        {
            if (_viewModel.SelctedPlayerInComboBox == null)
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

            var looser = _viewModel.SelctedMatchInTreeView.Participants.First(item => item != _viewModel.SelctedPlayerInComboBox);
            int numberRound = _viewModel.SelctedMatchInTreeView.ResolveWinner(_viewModel.SelectedTournament, _viewModel.SelctedPlayerInComboBox);
            if (_viewModel.SelectedTournament.OnlyForTeams)
            {
                _resultTournamentTeamService.SetTeamResultInRoundOfTournament(_viewModel.SelctedPlayerInComboBox.Id, 2,
                numberRound, _viewModel.SelectedTournament.Id);

                _resultTournamentTeamService.SetTeamResultInRoundOfTournament( looser.Id, 0,
                    numberRound, _viewModel.SelectedTournament.Id);
            }
            else
            {
                int idWinner = _resultTournamentPlayerService.SetPlayerResultInRoundOfTournament(2, _viewModel.SelctedPlayerInComboBox.Id,
                numberRound, _viewModel.SelectedTournament.Id);

                int idLoser = _resultTournamentPlayerService.SetPlayerResultInRoundOfTournament(0, looser.Id,
                    numberRound, _viewModel.SelectedTournament.Id);
            }
            _viewModel.VisibilityStackPanelMatchResolve = Visibility.Collapsed;

        }
    }
}
