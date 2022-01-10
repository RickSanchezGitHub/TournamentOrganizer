using System.Windows;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.Validation.TabItemTournamentValidation;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TournamentCommands
{
    public class DeleteTournamentCommand : CommandBase
    {
        private readonly TabItemTournamentsViewModel _viewModel;
        private readonly ITournamentService _tournamentService;

        public DeleteTournamentCommand(TabItemTournamentsViewModel viewModel, ITournamentService tournamentService) : base()
        {
            _viewModel = viewModel;
            _tournamentService = tournamentService;
        }

        public override void Execute(object parameter)
        {
            if (!TabItemTournamentValidation.DeleteTournamentValidation(_viewModel.TournamentParticipants))
            {
                MessageBox.Show("Невозможно удалить турнир пока в нем учавствуют люди",
                           "Ошибка ",
                           MessageBoxButton.OK);
                return;
            }
            _tournamentService.DeleteTournament(_viewModel.SelectedTournament.Id);
            _viewModel.Tournaments.Remove(_viewModel.SelectedTournament);
        }
    }
}
