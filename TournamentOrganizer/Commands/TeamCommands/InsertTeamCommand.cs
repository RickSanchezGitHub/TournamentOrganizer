﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.Command;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TeamCommands
{
    public class InsertTeamCommand : CommandBase
    {
        private TabItemTeamViewModel _viewModel;
        private ITeamService _teamService;
        public InsertTeamCommand(TabItemTeamViewModel viewModel, ITeamService teamService)
        {
            _viewModel = viewModel;
            _teamService = teamService;
        }
        public override void Execute(object parameter)
        {
            var teamModel = new TeamModel
            {
                Name = ""
            };
            int idNewTeam = _teamService.Insert(teamModel);
            teamModel.Id = idNewTeam;
            _viewModel.Teams.Add(teamModel);
        }
    }
}