using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Tabs
{
    /// <summary>
    /// Логика взаимодействия для TabItemGridOfTournaments.xaml
    /// </summary>
    public partial class TabItemGridOfTournaments : TabItem
    {
        private TabItemGridOfTournamentsViewModel _viewModel;
        public TabItemGridOfTournaments()
        {
            _viewModel = new();
            InitializeComponent();
            DataContext = _viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var data = button.DataContext;

            _viewModel.SelctedMatchInTreeView = (MatchModel)data;
            _viewModel.VisibilityStackPanelMatchResolve = Visibility.Visible;
        }

        private void ComboBox_Selected(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
