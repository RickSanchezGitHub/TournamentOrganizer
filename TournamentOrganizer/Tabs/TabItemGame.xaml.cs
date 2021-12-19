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
        private GameViewModel _currentEditGame;
        public TabItemGame()
        {
            InitializeComponent();
            DataContext = ViewModel;
            ViewModel = new TabItemGameViewModel();
            ViewModel.Games.Add(new GameViewModel { Name = "WoW" });
            ViewModel.Games.Add(new GameViewModel { Name = "Monopoly" });
            ViewModel.Games.Add(new GameViewModel { Name = "Durak" });
            DataGridListGames.ItemsSource = ViewModel.Games;
        }

        private void ButtonGameDelite_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var game = (GameViewModel)button.DataContext;
            ViewModel.Games.Remove(game);

        }

        private void ButtonGameEdit_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var game = (GameViewModel)button.DataContext;
            _currentEditGame = game;
            TextBoxAddGameName.Text = _currentEditGame.Name;

            ButtonAddEdit.Content = "Сохранить";
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TextBoxAddGameName.Text))
            {
                MessageBox.Show("Введите название игры");
                return;
            }

            if (ViewModel.Games.FirstOrDefault(item => item.Name == TextBoxAddGameName.Text) != null)
            {
                MessageBox.Show("Такая игра уже есть");
                return;
            }

            if ((string)ButtonAddEdit.Content == "Добавить")
            {
                ViewModel.Games.Add(new GameViewModel { Name = TextBoxAddGameName.Text });
            }
            else if ((string)ButtonAddEdit.Content == "Сохранить")
            {
                ButtonAddEdit.Content = "Добавить";
                _currentEditGame.Name = TextBoxAddGameName.Text;
            }
        }

        private void TextBoxAddGameName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBoxAddGameName.Text.Length > 25)
            {
                MessageBox.Show("Длинное название");
                return;
            }
        }
    }
}