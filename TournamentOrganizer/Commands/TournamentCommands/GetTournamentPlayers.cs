using System.Collections.ObjectModel;
using System.Windows;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TournamentCommands
{
    public class GetTournamentPlayers : CommandBase
    {
        private readonly TabItemTournamentsViewModel _viewModel;
        private readonly ITournamentService _tournamentService;

        public GetTournamentPlayers(TabItemTournamentsViewModel viewModel, ITournamentService tournamentService) : base()
        {
            _viewModel = viewModel;
            _tournamentService = tournamentService;
        }

        public override void Execute(object parameter)
        {
            _viewModel.TournamentParticipants.Clear();
            var playerList =  _tournamentService.GetPlayersInTournament(_viewModel.SelectedTournament.Id);
            foreach (var item in playerList)
            {
                _viewModel.TournamentParticipants.Add(item);
            }
            _viewModel.VisibilityDataGridPlayers = Visibility.Visible;
            _viewModel.VisibilityDataGridTournaments = Visibility.Collapsed;
            _viewModel.VisibilityBackPlayersButton = Visibility.Visible;
            _viewModel.VisibilityColumnParticipant = Visibility.Visible;
            _viewModel.VisibilityColumn = Visibility.Collapsed;
        }
    }
}