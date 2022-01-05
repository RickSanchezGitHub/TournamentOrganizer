using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.GridOfTournamentsCommands
{
    public class LoadTournamentsCommand: CommandBase
    {
        private TabItemGridOfTournamentsViewModel _viewModel;
        private readonly ITournamentService _tournamentService;
        public LoadTournamentsCommand(TabItemGridOfTournamentsViewModel viewModel, ITournamentService tournamentService)
        {
            _viewModel = viewModel;
            _tournamentService = tournamentService;
        }

        public override void Execute(object parameter)
        {
            foreach (var item in _tournamentService.GetAllTournaments())
                _viewModel.Tournaments.Add(item);
        }
    }
}
