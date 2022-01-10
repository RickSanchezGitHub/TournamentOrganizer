﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.DataLayer.Repositories;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.GridOfTournamentsCommands
{
    public class LoadTournamentsCommand : CommandBase
    {
        private TabItemGridOfTournamentsViewModel _viewModel;
        private readonly ResultTournamentPlayerService _resultTournamentPlayerService;
        private readonly ResultTournamentTeamService _resultTournamentTeamService;
        private readonly ITournamentService _tournamentService;

        public LoadTournamentsCommand(TabItemGridOfTournamentsViewModel viewModel, ResultTournamentPlayerService resultTournamentPlayerService, IPlayerService playerService, ITournamentService tournamentService)
        {
            _viewModel = viewModel;
            _resultTournamentPlayerService = resultTournamentPlayerService;
            _resultTournamentTeamService = new();
            _tournamentService = tournamentService;
        }

        public override void Execute(object parameter)
        {
            foreach (var item in _tournamentService.GetAllTournaments())
            {
                _viewModel.Tournaments.Add(item);
                if (item.OnlyForTeams)
                {
                    _resultTournamentTeamService.CreateTournamentFromDataBase(item);
                }
                else
                {
                    _resultTournamentPlayerService.CreateTournamentFromDataBase(item);
                }

            }
        }
    }
}
