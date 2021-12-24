using System.Windows.Controls;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Tabs
{
    public partial class TabItemTournament : TabItem
    {
        private TabItemTournamentsViewModel _viewModel;
        public TabItemTournament()
        {
            _viewModel = new TabItemTournamentsViewModel();
            InitializeComponent();
        }

    }
}
