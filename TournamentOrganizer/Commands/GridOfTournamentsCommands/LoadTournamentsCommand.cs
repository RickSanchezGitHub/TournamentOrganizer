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
    public class LoadTournamentsCommand: CommandBase
    {
        private TabItemGridOfTournamentsViewModel _viewModel;
        private readonly ResultTournamentPlayerService _resultTournamentPlayerService;
        private readonly IPlayerService _playerService;
        private readonly ITournamentService _tournamentService;

        public LoadTournamentsCommand(TabItemGridOfTournamentsViewModel viewModel, ResultTournamentPlayerService resultTournamentPlayerService, IPlayerService playerService, ITournamentService tournamentService)
        {
            _viewModel = viewModel;
            _resultTournamentPlayerService = resultTournamentPlayerService;
            _playerService = playerService;
            _tournamentService = tournamentService;
        }

        public override void Execute(object parameter)
        {
            foreach (var item in _tournamentService.GetAllTournaments())
            {
                _viewModel.Tournaments.Add(item);
                _resultTournamentPlayerService.CreateTournamentFromDataBase(item);
            }
        }
    }
}
