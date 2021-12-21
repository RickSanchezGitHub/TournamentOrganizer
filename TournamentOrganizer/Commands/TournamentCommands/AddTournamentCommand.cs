using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TournamentCommands
{
    public class AddTournamentCommand: CommandBase
    {
        private TabItemTournamentsViewModel _viewModel;
        private TournamentService _tournamentService;

        public AddTournamentCommand(TabItemTournamentsViewModel viewModel) : base()
        {
            _viewModel = viewModel;
            _tournamentService = _viewModel._tournamentService;
        }
        public override void Execute(object parameter)
        {
            
        }
    }
}
