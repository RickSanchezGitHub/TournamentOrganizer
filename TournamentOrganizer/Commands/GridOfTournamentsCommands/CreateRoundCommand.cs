using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands
{
    public class CreateRoundCommand: CommandBase
    {
        private TabItemGridOfTournamentsViewModel _viewModel;

        public CreateRoundCommand(TabItemGridOfTournamentsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if (_viewModel.SelectedTournament == null)
            {
                MessageBox.Show("Выберите турнир");
                return;
            }
            
            if (!_viewModel.SelectedTournament.CreateRound())
            {
                MessageBox.Show("В текущем раунде не во всех матчах установлен результат");
                return;
            }

        }
    }
}
