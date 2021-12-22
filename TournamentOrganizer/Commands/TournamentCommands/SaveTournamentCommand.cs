using System.Windows;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TournamentCommands
{
    public class SaveTournamentCommand : CommandBase
    {
        private TabItemTournamentsViewModel _viewModel;
        private TournamentService _tournamentService;

        public SaveTournamentCommand(TabItemTournamentsViewModel viewModel, TournamentService tournamentService) : base()
        {
            _viewModel = viewModel;
            _tournamentService = tournamentService;
        }
        public override void Execute(object parameter)
        {
            var tournament = new TournamentModel()
            {
                Name = _viewModel.TextBoxName,
                StartDate = _viewModel.DatePickerStartDate,
                CloseDate = _viewModel.DatePickerCloseDate,
                Game = _viewModel.SelectedGame
            };
            _viewModel.VisibilityColumn = Visibility.Collapsed;
            var insertedTournament = _tournamentService.InsertTournament(tournament);
            tournament.Id = insertedTournament;
            _viewModel.Tournaments.Add(tournament);

        }
    }
}
