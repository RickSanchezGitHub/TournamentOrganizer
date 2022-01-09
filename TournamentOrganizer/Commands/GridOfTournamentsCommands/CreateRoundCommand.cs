using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands
{
    public class CreateRoundCommand : CommandBase
    {
        private TabItemGridOfTournamentsViewModel _viewModel;
        private readonly ResultTournamentPlayerService _resultTournamentPlayerService;
        private readonly ResultTournamentTeamService _resultTournamentTeamService;
        public CreateRoundCommand(TabItemGridOfTournamentsViewModel viewModel)
        {
            _viewModel = viewModel;
            _resultTournamentPlayerService = new();
            _resultTournamentTeamService = new();
        }

        public override void Execute(object parameter)
        {
            if (_viewModel.SelectedTournament == null)
            {
                MessageBox.Show("Выберите турнир");
                return;
            }

            if (_viewModel.SelectedTournament.ClosedTournament == true)
            {
                MessageBox.Show("Турнир завершён");
                return;
            }

            if (_viewModel.SelectedTournament.StartedTournament == false)
            {
                MessageBox.Show("Турнир не начат");
                return;
            }

            if (!_viewModel.SelectedTournament.CreateRound())
            {
                MessageBox.Show("В текущем раунде не во всех матчах установлен результат");
                return;
            }

            foreach (var match in _viewModel.SelectedTournament.Rounds.Last<RoundModel>().Matchs)
            {
                foreach (var participant in match.Participants)
                {
                    int mn = match.MatchNumber;
                    int rn = _viewModel.SelectedTournament.Rounds.Last<RoundModel>().RoundNumber;
                    int tId = _viewModel.SelectedTournament.Id;
                    int pId = participant.Id;
                    IResultTournamentParticipantModel resultTournamentParticipantModel;
                    if (_viewModel.SelectedTournament.OnlyForTeams)
                    {
                        resultTournamentParticipantModel = new ResultTournamentTeamModel
                        {
                            NumberMatch = mn,
                            NumberRound = rn,
                            Tournament = _viewModel.SelectedTournament,
                            Team = participant as TeamModel,
                            Result = null
                        };
                        match.TeamsResults.Add(resultTournamentParticipantModel as ResultTournamentTeamModel);
                        if (_viewModel.SelectedTournament.Rounds.Last<RoundModel>().RoundNumber == 1)
                        {
                            _resultTournamentTeamService.SetMatchRoundInTournamentByTeamId(tId, pId, mn, rn);
                        }
                        else
                            _resultTournamentTeamService.InsertTeamIdRoundMatchTournament(pId, rn, mn, tId);
                    }
                    else
                    {
                        resultTournamentParticipantModel = new ResultTournamentPlayerModel
                        {
                            NumberMatch = mn,
                            NumberRound = rn,
                            Tournament = _viewModel.SelectedTournament,
                            Player = participant as PlayerModel,
                            Result = null
                        };
                        match.PlayersResults.Add(resultTournamentParticipantModel as ResultTournamentPlayerModel);
                        if (_viewModel.SelectedTournament.Rounds.Last<RoundModel>().RoundNumber == 1)
                        {
                            _resultTournamentPlayerService.SetMatchRoundByPlayerTournament(tId, pId, mn, rn);
                        }
                        else
                            _resultTournamentPlayerService.InsertPlayerIdRoundMatchTournament(pId, rn, mn, tId);
                    }
                    
                    
                }
            }

        }
    }
}
