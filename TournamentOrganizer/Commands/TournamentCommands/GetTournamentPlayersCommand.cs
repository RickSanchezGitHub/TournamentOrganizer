using System.Collections.ObjectModel;
using System.Windows;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TournamentCommands
{
    public class GetTournamentPlayersCommand : CommandBase
    {
        private readonly TabItemTournamentsViewModel _viewModel;
        private readonly ITournamentService _tournamentService;

        public GetTournamentPlayersCommand(TabItemTournamentsViewModel viewModel, ITournamentService tournamentService) : base()
        {
            _viewModel = viewModel;
            _tournamentService = tournamentService;
        }

        public override void Execute(object parameter)
        {
            _viewModel.TournamentParticipants.Clear();
            var tournamentPlayerList =  _tournamentService.GetPlayersInTournament(_viewModel.SelectedTournament.Id);
            foreach (var item in tournamentPlayerList)
            {
                _viewModel.TournamentParticipants.Add(item);
            }
            _viewModel.AllParticipants.Clear();
            var allPlayerList = _tournamentService.GetAllPlayers();
            foreach (var item in allPlayerList)
            {
                _viewModel.AllParticipants.Add(item);
            }
            _viewModel.VisibilityDataGridPlayers = Visibility.Visible;
            _viewModel.VisibilityDataGridTournaments = Visibility.Collapsed;
            _viewModel.VisibilityBackPlayersButton = Visibility.Visible;
            _viewModel.VisibilityColumnParticipant = Visibility.Visible;
            _viewModel.VisibilityColumn = Visibility.Collapsed;
        }
    }
}