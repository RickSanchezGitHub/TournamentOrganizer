using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.GridOfTournamentsCommands
{
    public class ShowTournamentParticipantsCommand : CommandBase
    {
        private TabItemGridOfTournamentsViewModel _viewModel;
        private ResultTournamentPlayerService _resultTournamentPlayerService;
        private ResultTournamentTeamService _resultTournamentTeamService;
        public ShowTournamentParticipantsCommand(TabItemGridOfTournamentsViewModel viewModel)
        {
            _viewModel = viewModel;
            _resultTournamentPlayerService = new();
            _resultTournamentTeamService = new();
        }

        public override void Execute(object parameter)
        {
            _viewModel.ParticipantTournamentResults.Clear();
            _viewModel.VisibilityStackPanelMatchResolve = Visibility.Collapsed;
            _viewModel.VisibilityDataGridShowTournamentParticipants = Visibility.Visible;
            _viewModel.VisibilityStackPanelMatchResolve = Visibility.Collapsed;
            _viewModel.VisibilityStackPanelRedistributeParticipants = Visibility.Collapsed;
            if (_viewModel.ShowParticipantsTournamentResult == "Показать участников турнира")
            {
                _viewModel.VisibilityDataGridShowTournamentParticipants = System.Windows.Visibility.Visible;
                _viewModel.ShowParticipantsTournamentResult = "Скрыть участников турнира";
            }
            else
            {
                _viewModel.VisibilityDataGridShowTournamentParticipants = System.Windows.Visibility.Collapsed;
                _viewModel.ShowParticipantsTournamentResult = "Показать участников турнира";
                return;
            }
            
            if (_viewModel.SelectedTournament.OnlyForTeams)
            {
                foreach (IParticipant item in _viewModel.SelectedTournament.Participants)
                {
                    ParticipantTournamentResult participantTournamentResult = new(item);
                    foreach (var results in _resultTournamentTeamService.GetTeamResultsInTournament(item.Id, _viewModel.SelectedTournament.Id))
                    {
                        participantTournamentResult.Score += (int)results.Result;
                    }
                    _viewModel.ParticipantTournamentResults.Add(participantTournamentResult);
                }
            }
            else
            {
                foreach (IParticipant item in _viewModel.SelectedTournament.Participants)
                {
                    ParticipantTournamentResult participantTournamentResult = new(item);
                    foreach (var results in _resultTournamentPlayerService.GetPlayerResultsInTournament(item.Id, _viewModel.SelectedTournament.Id))
                    {
                        participantTournamentResult.Score += (int)results.Result;
                    }
                    _viewModel.ParticipantTournamentResults.Add(participantTournamentResult);

                }
            }
            
            

        }
    }
}
