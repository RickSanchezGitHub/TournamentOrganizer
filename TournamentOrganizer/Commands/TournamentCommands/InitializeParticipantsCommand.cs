using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TournamentCommands
{
    class InitializeParticipantsCommand: CommandBase
    {
        private readonly TabItemTournamentsViewModel _viewModel;
        private readonly ITournamentService _tournamentService;

        public InitializeParticipantsCommand(TabItemTournamentsViewModel viewModel, ITournamentService tournamentService) : base()
        {
            _viewModel = viewModel;
            _tournamentService = tournamentService;
        }

        public override void Execute(object parameter)
        {
            _viewModel.AllParticipants.Clear();
            var playerList = _tournamentService.GetAllPlayers();
            foreach (var item in playerList)
            {
                _viewModel.AllParticipants.Add(item);
            }
            _viewModel.VisibilityDataGridPlayers = Visibility.Visible;
            _viewModel.VisibilityDataGridTournaments = Visibility.Collapsed;
            _viewModel.VisibilityBackPlayersButton = Visibility.Visible;
            _viewModel.VisibilityColumnParticipant = Visibility.Visible;
            _viewModel.VisibilityColumn = Visibility.Collapsed;
        }
    }
}
