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
            ViewModel.Games.Add(new GameViewModel { Name = "Poker" });
            ViewModel.Games.Add(new GameViewModel { Name = "Durak" });
            ViewModel.Games.Add(new GameViewModel { Name = "Monopoly" });
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
                DataGridParticipants.Columns.Clear();
                DataGridParticipants.Columns.Add(new DataGridTextColumn { Header = "Имя" });
                DataGridParticipants.Columns.Add(new DataGridTextColumn { Header = "Фамилия" });
                DataGridParticipants.Columns.Add(new DataGridTextColumn { Header = "Погоняло" });
                DataGridParticipants.Columns.Add(new DataGridTextColumn { Header = "Результат" });
                
            }
            else
            {
                DataGridParticipants.Columns.Clear();
                DataGridParticipants.Columns.Add(new DataGridTextColumn { Header = "Название" });
                DataGridParticipants.Columns.Add(new DataGridTextColumn { Header = "Результат" });
            }
        }
    }
}
