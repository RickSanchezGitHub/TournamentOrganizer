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
    public class ShowTournamentParticipantsCommand : CommandBase
    {
        private TabItemGridOfTournamentsViewModel _viewModel;
        private ResultTournamentPlayerService _resultTournamentPlayerService;
        public ShowTournamentParticipantsCommand(TabItemGridOfTournamentsViewModel viewModel)
        {
            _viewModel = viewModel;
            _resultTournamentPlayerService = new(); 
        }

        public override void Execute(object parameter)
        {
            //ПЕРЕНЕСТИ ВО ВЬЮ МОДЕЛЬ и забиндить
            //ObservableCollection<ParticipantTournamentResult> participantTournamentResults = new(); 
            //foreach (IParticipant item in _viewModel.SelectedTournament.Participants)
            //{
            //    ParticipantTournamentResult newParticipantResults = new (item);
            //    foreach (var results in _resultTournamentPlayerService.GetPlayerResultsInTournament(item.Id, _viewModel.SelectedTournament.Id))
            //    {
            //        newParticipantResults.Score += (int)results.Result;
            //    }
            //    participantTournamentResults.Add(newParticipantResults);
            //}

            //_viewModel.SelectedTournament.SetParticipantsResults();
            _viewModel.VisibilityDataGridShowTournamentParticipants = System.Windows.Visibility.Visible;

        }
    }
}
