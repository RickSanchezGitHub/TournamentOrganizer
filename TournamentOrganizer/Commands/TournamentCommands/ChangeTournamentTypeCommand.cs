using System.Collections.ObjectModel;
using System.Windows;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TournamentCommands
{
    public class ChangeTournamentTypeCommand : CommandBase
    {
        private readonly TabItemTournamentsViewModel _viewModel;

        public ChangeTournamentTypeCommand(TabItemTournamentsViewModel viewModel) : base()
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {

        }
    }
}
