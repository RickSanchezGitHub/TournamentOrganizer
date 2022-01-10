using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.GridOfTournamentsCommands
{
    public class SaveRedistributeCommand : CommandBase
    {
        private readonly TabItemGridOfTournamentsViewModel _viewModel;
        private readonly IResultTournamentPlayerService _resultTournamentPlayerService;
        private readonly IResultTournamentTeamService _resultTournamentTeamService;


        public SaveRedistributeCommand(TabItemGridOfTournamentsViewModel viewModel, IResultTournamentPlayerService resultTournamentPlayerService,
            IResultTournamentTeamService resultTournamentTeamService)
        {
            _viewModel = viewModel;
            _resultTournamentPlayerService = resultTournamentPlayerService;
            _resultTournamentTeamService = resultTournamentTeamService;

        }

        public override void Execute(object parameter)
        {
            MessageBoxResult userAnswer = MessageBox.Show($"Уверены что хотите сохранить изменения?", "Подтверждение",
                        MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (userAnswer == MessageBoxResult.No)
            {
                return;
            }
            if (_viewModel.SelectedTournament.OnlyForTeams)
            {
                _resultTournamentTeamService.DeleteByTournamentRound(_viewModel.SelectedTournament.Id, _viewModel.RoundForRedistribute.RoundNumber);
                foreach (MatchModel match in _viewModel.NewRound.Matchs)
                {
                    foreach (var result in match.ParticipantsResults)
                    {
                        int id = _resultTournamentTeamService.InsertTeamIdRoundMatchTournament(result as ResultTournamentTeamModel);
                        result.Id = id;
                    }
                }
            }
            else
            {
                _resultTournamentPlayerService.DeleteByTournamentRound(_viewModel.SelectedTournament.Id, _viewModel.RoundForRedistribute.RoundNumber);
                foreach (MatchModel match in _viewModel.NewRound.Matchs)
                {
                    foreach (var result in match.ParticipantsResults)
                    {
                        int id =_resultTournamentPlayerService.InsertPlayerIdRoundMatchTournament(result as ResultTournamentPlayerModel);
                        result.Id = id;
                    }
                }
            }

            _viewModel.SelectedTournament.Rounds.Remove(_viewModel.RoundForRedistribute);
            _viewModel.SelectedTournament.Rounds.Add(_viewModel.NewRound);
            _viewModel.IsEnabledButtonSaveRedistributeParticipants = false;
            _viewModel.IsEnabledButtonShowParticipantsResultsAndRedistribute = true;
        }
    }
}
