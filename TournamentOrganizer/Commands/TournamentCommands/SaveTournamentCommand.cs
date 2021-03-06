using System.Windows;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TournamentCommands
{
    public class SaveTournamentCommand : CommandBase
    {
        private readonly TabItemTournamentsViewModel _viewModel;
        private readonly ITournamentService _tournamentService;

        public SaveTournamentCommand(TabItemTournamentsViewModel viewModel, ITournamentService tournamentService) : base()
        {
            _viewModel = viewModel;
            _tournamentService = tournamentService;
        }
        public override void Execute(object parameter)
        {
            _viewModel.VisibilityColumn = Visibility.Collapsed;
            if (!Validation.Validation.TextBoxValidation(_viewModel.TextBoxName))
            {
                MessageBox.Show("Название содержит недопустьимые символы", "Ошибка ", MessageBoxButton.OK);
                return;
            }
            var tournament = new TournamentModel()
            {
                Name = _viewModel.TextBoxName,
                StartDate = _viewModel.DatePickerStartDate,
                CloseDate = _viewModel.DatePickerCloseDate,
                Game = _viewModel.SelectedGame,
                OnlyForTeams = _viewModel.CheckBoxSelectedTournamentType
            };
            var insertedTournament = _tournamentService.InsertTournament(tournament);
            tournament.Id = insertedTournament;
            _viewModel.Tournaments.Add(tournament);

        }
    }
}
