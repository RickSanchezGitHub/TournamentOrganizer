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
    public class SetDrawCommand : CommandBase
    {
        private TabItemGridOfTournamentsViewModel _viewModel;
        private readonly ResultTournamentPlayerService _resultTournamentPlayerService;
        private readonly ResultTournamentTeamService _resultTournamentTeamService;
        public SetDrawCommand(TabItemGridOfTournamentsViewModel viewModel)
        {
            _viewModel = viewModel;
            _resultTournamentPlayerService = new();
            _resultTournamentTeamService = new();
        }

        public override void Execute(object parameter)
        {
            MessageBoxResult userAnswer = MessageBox.Show($"Установить ничью?", "Подтверждение",
                        MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (userAnswer == MessageBoxResult.No)
                return;
            
            var participantsResults = _viewModel.SelctedMatchInTreeView.ParticipantsResults;
            foreach (var item in participantsResults)
            {
                int numberRound = _viewModel.SelctedMatchInTreeView.ResolveDraw(_viewModel.SelectedTournament, item);
                item.Tournament = _viewModel.SelectedTournament;
                if (_viewModel.SelectedTournament.OnlyForTeams)
                    _resultTournamentTeamService.SetTeamResultInRoundOfTournament(item as ResultTournamentTeamModel, 1);
                else
                    _resultTournamentPlayerService.SetPlayerResultInRoundOfTournament(1, item as ResultTournamentPlayerModel);
            }
            _viewModel.VisibilityStackPanelMatchResolve = Visibility.Collapsed;
            _viewModel.SelctedPlayerInComboBox = null;
        }
    }
}
