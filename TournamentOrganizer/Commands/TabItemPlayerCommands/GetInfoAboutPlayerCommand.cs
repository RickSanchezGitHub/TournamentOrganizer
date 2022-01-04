using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TournamentOrganizer.BusinessLayer.Configuration;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.Command;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands
{
    public class GetInfoAboutPlayerCommand : CommandBase
    {
        private TabItemPlayerViewModel _viewModel;
        private readonly IPlayerService _playerService;

        public GetInfoAboutPlayerCommand(TabItemPlayerViewModel viewModel, IPlayerService playerService) : base()
        {
            _viewModel = viewModel;
            _playerService = playerService;
        }
        public override void Execute(object parameter)
        {
            _viewModel.SelectedPlayer = _viewModel.SelectedDeletePlayer;
            _viewModel.Teams = new ObservableCollection<TeamModel>(_playerService.GetTeamsByPlayerId(_viewModel.SelectedPlayer.Id));
            _viewModel.WidthGridPlayerInfo = new GridLength(1, GridUnitType.Star);
            _viewModel.StateMainDataGrid = false;
            _viewModel.IsEnabledButtonAdd = false;

        }
    }
}