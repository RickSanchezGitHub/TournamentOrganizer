using System.Windows;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TournamentCommands
{
    public class AddPlayerToTournamentCommand : CommandBase
    {
        private readonly TabItemTournamentsViewModel _viewModel;
        private readonly ITournamentService _tournamentService;

        public AddPlayerToTournamentCommand(TabItemTournamentsViewModel viewModel, ITournamentService tournamentService) : base()
        {
            _viewModel = viewModel;
            _tournamentService = tournamentService;
        }
        public override void Execute(object parameter)
        {
            //_viewModel.VisibilityColumn = Visibility.Collapsed;
            //var player = _viewModel.ComboBoxSelectedPlayer;
            //var playerId = _tournamentService.AddPalyerToTournament;
            //player.Id = playerId;
            //_viewModel.Tournaments.Add(player);

        }
    }
}
