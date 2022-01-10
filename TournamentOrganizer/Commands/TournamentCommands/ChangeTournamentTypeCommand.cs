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
            //if (_viewModel.ComboBoxSelectTournamentType == "Командные турниры")
            //{
            //    _viewModel.VisibilityDataGridTeamTournaments = Visibility.Visible;
            //    _viewModel.VisibilityDataGridPlayersTournaments = Visibility.Collapsed;
            //}
            //if (_viewModel.ComboBoxSelectTournamentType == "Турниры для игроков")
            //{
            //    _viewModel.VisibilityDataGridTeamTournaments = Visibility.Collapsed;
            //    _viewModel.VisibilityDataGridPlayersTournaments = Visibility.Visible;
            //}
        }
    }
}
