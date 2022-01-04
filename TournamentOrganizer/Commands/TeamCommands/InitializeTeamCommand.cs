using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.BusinessLayer.Service.PlayerService;
using TournamentOrganizer.BusinessLayer.Service.TeamService;
using TournamentOrganizer.UI.Command;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TeamCommands
{
    public class InitializeTeamCommand : CommandBase
    {
        private readonly TabItemTeamViewModel _viewModel;
        private readonly ITeamService _teamService;
        private readonly IPlayerService _playerService;
        public InitializeTeamCommand(TabItemTeamViewModel viewModel, ITeamService teamService, IPlayerService playerService)
        {
            _viewModel = viewModel;
            _teamService = teamService;
            _playerService = playerService;
        }

        public override void Execute(object parameter)
        {
            _viewModel.Teams = new ObservableCollection<TeamModel>(_teamService.GetAll());
            _viewModel.Players = new ObservableCollection<PlayerModel>(_playerService.GetAll());
        }
    }
}
