using System.Linq;
using System.Windows;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.GridOfTournamentsCommands
{
    public class RedistributeParticipantsCommand : CommandBase
    {
        private readonly TabItemGridOfTournamentsViewModel _viewModel;
        public RedistributeParticipantsCommand(TabItemGridOfTournamentsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {

            _viewModel.VisibilityStackPanelMatchResolve = Visibility.Collapsed;
            _viewModel.VisibilityDataGridShowTournamentParticipants = Visibility.Collapsed;
            _viewModel.VisibilityStackPanelMatchResolve = Visibility.Collapsed;
            _viewModel.ShowParticipantsTournamentResult = "Показать участников турнира";

            if (_viewModel.SelectedTournament.ClosedTournament && _viewModel.SelectedTournament.Rounds.Last<RoundModel>().CheckMatchesOnResolved())
            {
                MessageBox.Show("Турнир уже завершён");
                return;
            }

            if (!_viewModel.SelectedTournament.StartedTournament)
            {
                MessageBox.Show("Турнир не начат");
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

            _viewModel.IsEnabledButtonShowParticipantsResultsAndRedistribute = false;
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
