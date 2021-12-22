using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TournamentOrganizer.BusinessLayer.Configuration;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.UI.Command;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands
{
    public class GetInfoAboutPlayerCommand : CommandBase
    {
        private TabItemPlayerViewModel _viewModel;

        public GetInfoAboutPlayerCommand(TabItemPlayerViewModel viewModel) : base()
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            _viewModel.SelectedPlayer = _viewModel.SelectedDeletePlayer;
            _viewModel.Teams = new ObservableCollection<TeamModel>(_viewModel.PlayerService.GetTeamsByPlayerId(_viewModel.SelectedPlayer.Id));
            _viewModel.WidthGridPlayerInfo = new GridLength(1, GridUnitType.Star);
            _viewModel.StateMainDataGrid = false;

        }
    }
}