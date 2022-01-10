using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands
{
    public class TournamentSelectCommand : CommandBase
    {
        private TabItemGridOfTournamentsViewModel _viewModel;

        private readonly ITournamentService _tournamentService;

        public TournamentSelectCommand(TabItemGridOfTournamentsViewModel viewModel, ITournamentService tournamentService) : base()
        {
            _viewModel = viewModel;
            _tournamentService = tournamentService;
        }

        public override void Execute(object parameter)
        {


        }
    }
}
