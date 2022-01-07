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
    public class CreateRoundCommand: CommandBase
    {
        private TabItemGridOfTournamentsViewModel _viewModel;
        private readonly ResultTournamentPlayerService _resultTournamentPlayerService;
        public CreateRoundCommand(TabItemGridOfTournamentsViewModel viewModel)
        {
            _viewModel = viewModel;
            _resultTournamentPlayerService = new();
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

            //ИНСЕРТ С ПОМОЩЬЮ ЭТОЙ ЗАЛУПНИ ВСЁ КРОМЕ РЕЗАЛТА
            foreach (var match in _viewModel.SelectedTournament.Rounds.Last<RoundModel>().Matchs)
            {
                foreach (var participant in match.Participants)
                {
                    int mn = match.MatchNumber;
                    int rn = _viewModel.SelectedTournament.Rounds.Last<RoundModel>().RoundNumber;
                    int tId = _viewModel.SelectedTournament.Id;
                    int pId = participant.Id;

                    if(_viewModel.SelectedTournament.Rounds.Last<RoundModel>().RoundNumber == 1)
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
