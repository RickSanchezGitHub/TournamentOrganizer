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
            if (_viewModel.SelectedTournament.OnlyForTeams != true)
            {
                var player = _viewModel.SelectedTournamentParticipant as PlayerModel;
                _tournamentService.AddPalyerToTournament(player, _viewModel.SelectedTournament.Id);
                _viewModel.TournamentParticipants.Add(player);
            } else
            {
                var team = _viewModel.SelectedTournamentParticipant as TeamModel;
                _tournamentService.AddTeamToTournament(team, _viewModel.SelectedTournament.Id);
                _viewModel.TournamentParticipants.Add(team);
            }
            
        }
    }
}
