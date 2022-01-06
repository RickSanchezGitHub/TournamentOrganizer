using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.GridOfTournamentsCommands
{
    public class StartTournamentCommand: CommandBase
    {
        private readonly TabItemGridOfTournamentsViewModel _viewmodel;

        public StartTournamentCommand(TabItemGridOfTournamentsViewModel viewmodel)
        {
            _viewmodel = viewmodel;
        }

        public override void Execute(object parameter)
        {
            var tournament = _viewmodel.SelectedTournament;
            if (tournament.Participants.Count == 0)
            {
                MessageBox.Show("Перед началом турнира необходимо зарегестрировать участников");
                return;
            }
            tournament.StartTournament();
            _viewmodel.VisibilityButtonForStartTournament = Visibility.Hidden;
            MessageBox.Show($"Турнир {tournament.Name} начат");
        }
    }
}
