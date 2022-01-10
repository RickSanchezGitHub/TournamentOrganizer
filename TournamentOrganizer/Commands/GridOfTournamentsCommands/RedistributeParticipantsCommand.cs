using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.GridOfTournamentsCommands
{
    public class RedistributeParticipantsCommand : CommandBase
    {
        private TabItemGridOfTournamentsViewModel _viewModel;
        private readonly ResultTournamentPlayerService _resultTournamentPlayerService;
        private readonly ResultTournamentTeamService _resultTournamentTeamService;
        public RedistributeParticipantsCommand(TabItemGridOfTournamentsViewModel viewModel)
        {
            _viewModel = viewModel;
            _resultTournamentPlayerService = new();
            _resultTournamentTeamService = new();
        }

        public override void Execute(object parameter)
        {
            if (_viewModel.SelectedTournament.ClosedTournament && _viewModel.SelectedTournament.Rounds.Last<RoundModel>().CheckMatchesOnResolved())
            {
                MessageBox.Show("Турнир уже завершён");
                return;
            }
            foreach (MatchModel match in _viewModel.SelectedTournament.Rounds.Last<RoundModel>().Matchs)
            {
                if (match.MatchResolved == true)
                {
                    MessageBox.Show("Раунд уже начался");
                    return;
                }
            }
            MessageBoxResult userAnswer = MessageBox.Show($"Уверены что хотите распределить участников самостоятельно?", "Подтверждение",
                        MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (userAnswer == MessageBoxResult.No)
            {
                return;
            }

            _viewModel.VisibilityStackPanelMatchResolve = Visibility.Collapsed;
            _viewModel.VisibilityDataGridShowTournamentParticipants = Visibility.Collapsed;
            _viewModel.VisibilityStackPanelMatchResolve = Visibility.Collapsed;
            _viewModel.VisibilityStackPanelRedistributeParticipants = Visibility.Visible;
            _viewModel.RoundForRedistribute = _viewModel.SelectedTournament.Rounds.Last<RoundModel>();
            _viewModel.NewRound = new RoundModel { RoundNumber = _viewModel.RoundForRedistribute.RoundNumber };
            foreach (var item in _viewModel.RoundForRedistribute.Matchs)
            {
              _viewModel.NewRound.Matchs.Add(new MatchModel { MatchNumber = item.MatchNumber, MatchResolved = false });
            }


            _viewModel.ParticipantsForRedistribution.Clear();
            foreach (IParticipant participant in _viewModel.SelectedTournament.Participants)
                _viewModel.ParticipantsForRedistribution.Add(participant);


        }
    }
}
