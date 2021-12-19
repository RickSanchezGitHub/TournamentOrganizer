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
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Tabs
{
    /// <summary>
    /// Логика взаимодействия для TabItemGame.xaml
    /// </summary>
    public partial class TabItemGame : TabItem
    {
        public TabItemGameViewModel ViewModel;

        public TabItemGame()
        {
            InitializeComponent();
            ViewModel = new TabItemGameViewModel();
            ViewModel.Games.Add(new GameViewModel { Name = "WoW" } ) ;
            DataGridListGames.ItemsSource = ViewModel.Games;
        }

        private void ButtonGameDelite_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
