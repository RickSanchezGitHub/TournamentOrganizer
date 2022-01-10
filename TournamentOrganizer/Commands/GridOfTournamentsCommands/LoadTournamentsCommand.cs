using System;
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
        private readonly TabItemGridOfTournamentsViewModel _viewModel;
        private readonly IResultTournamentPlayerService _resultTournamentPlayerService;
        private readonly IResultTournamentTeamService _resultTournamentTeamService;
        private readonly ITournamentService _tournamentService;

        public LoadTournamentsCommand(TabItemGridOfTournamentsViewModel viewModel, 
            IResultTournamentPlayerService resultTournamentPlayerService,
            IResultTournamentTeamService resultTournamentTeamService,
            ITournamentService tournamentService)
        {
            _viewModel = viewModel;
            _resultTournamentPlayerService = resultTournamentPlayerService;
            _resultTournamentTeamService = resultTournamentTeamService;
            _tournamentService = tournamentService;
        }

        public override void Execute(object parameter)
        {
            foreach (var item in _tournamentService.GetAllTournaments())
            {
                _viewModel.Tournaments.Add(item);
                if (item.OnlyForTeams)
                {
                    HelperForLoadAndSorted.CreateTournamentFromDataBase(item, _resultTournamentTeamService);
                }
                else
                {
                    HelperForLoadAndSorted.CreateTournamentFromDataBase(item, _resultTournamentPlayerService);
                }

            }
        }
    }
}
