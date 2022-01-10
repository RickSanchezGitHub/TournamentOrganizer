using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.GridOfTournamentsCommands
{
    public class SaveRedistributeCommand : CommandBase
    {
        private TabItemGridOfTournamentsViewModel _viewModel;
        private readonly ResultTournamentPlayerService _resultTournamentPlayerService;
        private readonly ResultTournamentTeamService _resultTournamentTeamService;


        public SaveRedistributeCommand(TabItemGridOfTournamentsViewModel viewModel)
        {
            _viewModel = viewModel;
            _resultTournamentPlayerService = new();
            _resultTournamentTeamService = new();

        }

        public override void Execute(object parameter)
        {

            if (_viewModel.SelectedTournament.OnlyForTeams)
            {
                _resultTournamentTeamService.DeleteByTournamentRound(_viewModel.SelectedTournament.Id, _viewModel.RoundForRedistribute.RoundNumber);
                foreach (MatchModel match in _viewModel.NewRound.Matchs)
                {
                    foreach (var result in match.TeamsResults)
                        _resultTournamentTeamService.UpdateTeamInMatchRoundTournament(result.Team.Id, _viewModel.SelectedTournament.Id, (int)result.NumberRound, (int)result.NumberMatch);
                    
                }
            }
            else
            {
                _resultTournamentPlayerService.DeleteByTournamentRound(_viewModel.SelectedTournament.Id, _viewModel.RoundForRedistribute.RoundNumber);
                foreach (MatchModel match in _viewModel.NewRound.Matchs)
                {
                    foreach (var result in match.PlayersResults)
                        _resultTournamentPlayerService.UpdatePlayerInMatchRoundTournament(result.Player.Id, _viewModel.SelectedTournament.Id, (int)result.NumberRound, (int)result.NumberMatch);
                    
                }
            }



            _viewModel.SelectedTournament.Rounds.Remove(_viewModel.RoundForRedistribute);
            _viewModel.SelectedTournament.Rounds.Add(_viewModel.NewRound);
        }
    }
}
