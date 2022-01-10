using System.Linq;
using System.Windows;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.Commands.GridOfTournamentsCommands;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands
{
    public class CreateRoundCommand : CommandBase
    {
        private readonly TabItemGridOfTournamentsViewModel _viewModel;
        private readonly IResultTournamentPlayerService _resultTournamentPlayerService;
        private readonly IResultTournamentTeamService _resultTournamentTeamService;
        public CreateRoundCommand(TabItemGridOfTournamentsViewModel viewModel, IResultTournamentPlayerService resultTournamentPlayerService,
            IResultTournamentTeamService resultTournamentTeamService)
        {
            _viewModel = viewModel;
            _resultTournamentPlayerService = resultTournamentPlayerService;
            _resultTournamentTeamService = resultTournamentTeamService;
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
            //huita
            HelperForLoadAndSorted.SortResultInTournament(_viewModel.SelectedTournament, _resultTournamentPlayerService, _resultTournamentTeamService);
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

                        if (_viewModel.SelectedTournament.Rounds.Last<RoundModel>().RoundNumber == 1)
                        {
                            _resultTournamentTeamService.DeleteByTeamIdAndTournamentId(pId, tId);
                        }

                        int id = _resultTournamentTeamService.InsertTeamIdRoundMatchTournament(resultTournamentParticipantModel as ResultTournamentTeamModel);
                        resultTournamentParticipantModel.Id = id;

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

                        if (_viewModel.SelectedTournament.Rounds.Last<RoundModel>().RoundNumber == 1)
                        {
                            _resultTournamentPlayerService.DeleteByPlayerIdAndTournamentId(pId, tId);
                        }

                        int id = _resultTournamentPlayerService.InsertPlayerIdRoundMatchTournament(resultTournamentParticipantModel as ResultTournamentPlayerModel);
                        resultTournamentParticipantModel.Id = id;

                    }
                    match.ParticipantsResults.Add(resultTournamentParticipantModel);

                }
            }

        }
    }
}
