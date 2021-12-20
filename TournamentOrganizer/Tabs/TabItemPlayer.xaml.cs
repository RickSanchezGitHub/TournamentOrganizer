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
    /// Interaction logic for TabItemPlayer.xaml  
    /// </summary>  
    public partial class TabItemPlayer : TabItem
    {
        public TabItemPlayerViewModel ViewModel;
        private PlayerViewModel _player;
        public TabItemPlayer()
        {
            InitializeComponent();
            ViewModel = new TabItemPlayerViewModel();
            DataContext = ViewModel;
            InitTestData();


        }

        private void InitTestData()
        {
            ViewModel.Players.Add(new PlayerViewModel { FirstName = "Иван", LastName = "Ivanov", NickName = "vanya", Email = "vanya@com", Birthday = DateTime.Today.AddYears(-20) });
            ViewModel.Players.Add(new PlayerViewModel { FirstName = "Petya", LastName = "Petrov", NickName = "vasya", Email = "vaa@com", Birthday = DateTime.Today.AddYears(-30) });
            ViewModel.Players.Add(new PlayerViewModel { FirstName = "Stas", LastName = "Sidorov", NickName = "sidor", Email = "vya@com", Birthday = DateTime.Today.AddYears(-22) });
        }

        private void ButtonAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.WidthGridAddPlayer = new GridLength(1, GridUnitType.Star);
            ViewModel.StateMainDataGrid = false;
        }

        private void ButtonSavePlayer_Click(object sender, RoutedEventArgs e)
        {
            if (TextIsNullorWhiteSpace(TextBoxFirstName) || TextIsNullorWhiteSpace(TextBoxLastName)
                || TextIsNullorWhiteSpace(TextBoxNickName) || TextIsNullorWhiteSpace(TextBoxEmail))
            {
                MessageBox.Show("Зполните все поля");
                return;
            }
            if (ViewModel.Players.FirstOrDefault(item => item.Email == TextBoxEmail.Text.Trim()) != null)
            {
                MessageBox.Show("Такой email уже существует");
                return;
            }
            if (ViewModel.Players.FirstOrDefault(item => item.NickName == TextBoxNickName.Text.Trim()) != null)
            {
                MessageBox.Show("Такой псевдоним уже существует");
                return;
            }

            ViewModel.Players.Add(new PlayerViewModel
            {
                FirstName = TextBoxFirstName.Text.Trim(),
                LastName = TextBoxLastName.Text.Trim(),
                NickName = TextBoxNickName.Text.Trim(),
                Email = TextBoxEmail.Text.Trim(),
                Birthday = DatePickerBirthday.SelectedDate
            });
            ViewModel.WidthGridAddPlayer = new GridLength(0, GridUnitType.Star);
            ViewModel.StateMainDataGrid = true;
        }

        private bool TextIsNullorWhiteSpace(TextBox textBox)
        {
            if (String.IsNullOrWhiteSpace(textBox.Text))
            {

                return true;
            }
            return false;
        }

        //private bool TextIsUnique(string text)  
        //{  
        //    if ( ViewModel.Players.FirstOrDefault(item => item.Email == text) == null)  
        //    {  
        //        return true;  
        //    }  
        //    return false;  
        //}  

        private void ButtonGetInfo_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            ViewModel.SelectedPlayer = (PlayerViewModel)button.DataContext;
            ViewModel.WidthGridPlayerInfo = new GridLength(1, GridUnitType.Star);
            ViewModel.StateMainDataGrid = false;
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            PlayerViewModel player = (PlayerViewModel)button.DataContext;
            ViewModel.Players.Remove(player);

        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            PlayerViewModel player = (PlayerViewModel)button.DataContext;

            ViewModel.WidthGridAddPlayer = new GridLength(1, GridUnitType.Star);
            TextBoxFirstName.Text = player.FirstName;
            TextBoxLastName.Text = player.LastName;
            TextBoxNickName.Text = player.NickName;
            TextBoxEmail.Text = player.Email;
            DatePickerBirthday.SelectedDate = player.Birthday;
            ViewModel.Players.Remove(player);
            ViewModel.StateMainDataGrid = false;

        }
        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.WidthGridPlayerInfo = new GridLength(0, GridUnitType.Star);
            ViewModel.StateMainDataGrid = true;
        }
    }
}
