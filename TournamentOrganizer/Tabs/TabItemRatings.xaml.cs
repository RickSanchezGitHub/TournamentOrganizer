using System;
using System.Collections;
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
using TournamentOrganizer.UI.VeiwModels.EntitiesVM;
using TournamentOrganizer.UI.VeiwModels.TabItemsVM;

namespace TournamentOrganizer.UI.Tabs
{
    /// <summary>
    /// Логика взаимодействия для TabItemRatings.xaml
    /// </summary>
    public partial class TabItemRatings : TabItem
    {
        public TabItemRatingsViewModel ViewModel;
        
        public TabItemRatings()
        {
            InitializeComponent();
            ViewModel = new TabItemRatingsViewModel();
            ViewModel.Games.Add(new GameModel { Name = "Poker" });
            ViewModel.Games.Add(new GameModel { Name = "Durak" });
            ViewModel.Games.Add(new GameModel { Name = "Monopoly" });
            //ViewModel.ResultsTournamentPlayer.Add(new PlayerRatingViewModel { FirstName = "Nikita", LastName = "auf", Name = "nick" });
            //ViewModel.ResultsTournamentPlayer.Add(new PlayerRatingViewModel { FirstName = "Nikita", LastName = "auf", Name = "nick" });
            //ViewModel.ResultsTournamentPlayer.Add(new PlayerRatingViewModel { FirstName = "Nikita", LastName = "auf", Name = "nick" });
            //ViewModel.ResultsTournamentPlayer.Add(new PlayerRatingViewModel { FirstName = "Nikita", LastName = "auf", Name = "nick" });

            DataContext = ViewModel;
            ComboBoxSelectGame.ItemsSource = ViewModel.Games;
        }

        private void ComboBoxSelectGame_Selected(object sender, RoutedEventArgs e)
        {
            StackPanelRatingViewManager.Visibility = Visibility.Visible;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radioButton = (RadioButton)sender;

            if (radioButton.Name == "RadioButtonPlayers")
            {
                DataGridTeams.Visibility = Visibility.Hidden;
                DataGridPlayers.Visibility = Visibility.Visible;
                DataGridPlayers.ItemsSource = ViewModel.ResultsTournamentPlayer;
            }
            else
            {
                DataGridPlayers.Visibility = Visibility.Hidden;
                DataGridTeams.Visibility = Visibility.Visible;
                DataGridTeams.ItemsSource = ViewModel.Teams;
            }
        }

        private void DataGridSetHeaderInColumns(IEnumerable headers, IEnumerable source)
        {
            
        }
    }
}
