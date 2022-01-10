using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TournamentCommands
{
    public class GetTournamentPlayersCommand : CommandBase
    {
        private readonly TabItemTournamentsViewModel _viewModel;
        private readonly ITournamentService _tournamentService;

        public GetTournamentPlayersCommand(TabItemTournamentsViewModel viewModel, ITournamentService tournamentService) : base()
        {
            _viewModel = viewModel;
            _tournamentService = tournamentService;
        }

        public override void Execute(object parameter)
        {
            _viewModel.TournamentParticipants.Clear();
            List<IParticipant> tournamentParticippantList = new List<IParticipant>();
            if (_viewModel.SelectedTournament.OnlyForTeams == true)
            {
                tournamentParticippantList = new List<IParticipant>(_tournamentService.GetTeamsInTournament(_viewModel.SelectedTournament.Id));
            }
            else
            {
                tournamentParticippantList = new List<IParticipant>(_tournamentService.GetPlayersInTournament(_viewModel.SelectedTournament.Id));
            }

            foreach (var item in tournamentParticippantList)
            {
                _viewModel.TournamentParticipants.Add(item);
            }
            _viewModel.AllParticipants.Clear();

            List<IParticipant> allParticipants = new List<IParticipant>();
            if (_viewModel.SelectedTournament.OnlyForTeams == true)
            {
                allParticipants = new List<IParticipant>(_tournamentService.GetAllTeams());
            }
            else
            {
                allParticipants = new List<IParticipant>(_tournamentService.GetAllPlayers());
            }
            foreach (var item in allParticipants)
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