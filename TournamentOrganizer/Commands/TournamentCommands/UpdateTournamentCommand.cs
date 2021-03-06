using System.Windows;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TournamentCommands
{
    public class UpdateTournamentCommand : CommandBase
    {
        private readonly TabItemTournamentsViewModel _viewModel;
        private readonly ITournamentService _tournamentService;

        public UpdateTournamentCommand(TabItemTournamentsViewModel viewModel, ITournamentService tournamentService) : base()
        {
            _viewModel = viewModel;
            _tournamentService = tournamentService;
        }
        public override void Execute(object parameter)
        {
            _viewModel.VisibilityColumn = Visibility.Collapsed;
            _viewModel.SelectedTournament.Name = _viewModel.TextBoxName;
            _viewModel.SelectedTournament.StartDate = _viewModel.DatePickerStartDate;
            _viewModel.SelectedTournament.CloseDate = _viewModel.DatePickerCloseDate;
            _viewModel.SelectedTournament.Game = _viewModel.SelectedGame;
            var tournament = new TournamentModel()
            {
                Id = _viewModel.SelectedTournament.Id,
                Name = _viewModel.SelectedTournament.Name,
                StartDate = _viewModel.SelectedTournament.StartDate,
                CloseDate = _viewModel.SelectedTournament.CloseDate,
                Game = _viewModel.SelectedTournament.Game,
                OnlyForTeams = _viewModel.CheckBoxSelectedTournamentType
            };
            _tournamentService.UpdateTournament(tournament);

        }
    }
}
