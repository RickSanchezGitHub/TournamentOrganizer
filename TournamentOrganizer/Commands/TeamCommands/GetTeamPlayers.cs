﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.BusinessLayer.Service.PlayerService;
using TournamentOrganizer.BusinessLayer.Service.TeamPlayerService;
using TournamentOrganizer.BusinessLayer.Service.TeamService;
using TournamentOrganizer.UI.Command;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TeamCommands
{
    public class GetTeamPlayers : CommandBase
    {
        private readonly TabItemTeamViewModel _viewModel;

        private readonly ITeamService _teamService;
        public GetTeamPlayers(TabItemTeamViewModel viewModel, ITeamService teamService)
        {
            _viewModel = viewModel;
            _teamService = teamService;
        }
        public override void Execute(object parameter)
        {
            var teamWithPlayers = _teamService.GetById(_viewModel.SelectedTeam.Id);
            if (teamWithPlayers.Players.Count >= 1 && teamWithPlayers.Players.FirstOrDefault() != null)
            {
                _viewModel.SelectedTeam.Players = teamWithPlayers.Players;
            }         
        }
    }
}