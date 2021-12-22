using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for TabItemPlayer.xaml  
    /// </summary>  
    public partial class TabItemPlayer : TabItem
    {
        public TabItemPlayerViewModel ViewModel;
        private PlayerModel _player;
        public TabItemPlayer()
        {
            InitializeComponent();
            ViewModel = new TabItemPlayerViewModel();
            DataContext = ViewModel;
            //InitTestData();


        }

        //private void InitTestData()
        //{
        //    ViewModel.Players.Add(new PlayerModel { FirstName = "Иван", LastName = "Ivanov", NickName = "vanya", Email = "vanya@com", Birthday = DateTime.Today.AddYears(-20) });
        //    ViewModel.Players.Add(new PlayerModel { FirstName = "Petya", LastName = "Petrov", NickName = "vasya", Email = "vaa@com", Birthday = DateTime.Today.AddYears(-30) });
        //    ViewModel.Players.Add(new PlayerModel { FirstName = "Stas", LastName = "Sidorov", NickName = "sidor", Email = "vya@com", Birthday = DateTime.Today.AddYears(-22) });
        //}

        private void ButtonAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.TextBoxFirstNameText = null;
            ViewModel.TextBoxLastNameText = null;
            ViewModel.TextBoxNickNameText = null;
            ViewModel.TextBoxEmailText = null;
            ViewModel.DatePickerBirthdaySelectedDate = DateTime.Now;

            ViewModel.WidthGridAddPlayer = new GridLength(1, GridUnitType.Star);
            ViewModel.StateMainDataGrid = false;
            //ViewModel.SelectedPlayer = null;
            ViewModel.IsEnabledButtonAddSave = true;
            ViewModel.VisibilityButtonAddSave = Visibility.Visible;

        }

        private void ButtonSaveEditPlayer_Click(object sender, RoutedEventArgs e)
        {
            if (TextIsNullorWhiteSpace(TextBoxFirstName) || TextIsNullorWhiteSpace(TextBoxLastName)
                || TextIsNullorWhiteSpace(TextBoxNickName) || TextIsNullorWhiteSpace(TextBoxEmail))
            {
                MessageBox.Show("Зполните все поля");
                return;
            }
            //if (ViewModel.Players.FirstOrDefault(item => item.Email == TextBoxEmail.Text.Trim()) != null)
            //{
            //    MessageBox.Show("Такой email уже существует");
            //    return;
            //}
            //if (ViewModel.Players.FirstOrDefault(item => item.NickName == TextBoxNickName.Text.Trim()) != null)
            //{
            //    MessageBox.Show("Такой псевдоним уже существует");
            //    return;
            //}

            ViewModel.SelectedPlayer.FirstName = ViewModel.TextBoxFirstNameText;
            ViewModel.SelectedPlayer.LastName = ViewModel.TextBoxLastNameText ;
            ViewModel.SelectedPlayer.NickName = ViewModel.TextBoxNickNameText ;
            ViewModel.SelectedPlayer.Email = ViewModel.TextBoxEmailText;
            ViewModel.SelectedPlayer.Birthday = ViewModel.DatePickerBirthdaySelectedDate;
            ViewModel.PlayerService.PlayerUpdate(ViewModel.SelectedPlayer.Id, ViewModel.SelectedPlayer);
            ViewModel.IsEnabledButtonEditSave = false;
            ViewModel.VisibilityButtonEditSave = Visibility.Hidden;

            //ViewModel.Players.Remove(ViewModel.SelectedPlayer);

            //ViewModel.Players.Add(new PlayerModel 
            //{ 
            //FirstName=ViewModel.TextBoxFirstNameText,
            //LastName = ViewModel.TextBoxLastNameText,
            //NickName = ViewModel.TextBoxNickNameText,
            //Email = ViewModel.TextBoxEmailText,
            //Birthday = ViewModel.DatePickerBirthdaySelectedDate
            //});
            ViewModel.WidthGridAddPlayer = new GridLength(0, GridUnitType.Star);
            ViewModel.StateMainDataGrid = true;
        }

        private void ButtonSaveAddedPlayer_Click(object sender, RoutedEventArgs e)
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
            var playerModel = new PlayerModel
            {
                FirstName = ViewModel.TextBoxFirstNameText,
                LastName = ViewModel.TextBoxLastNameText,
                NickName = ViewModel.TextBoxNickNameText,
                Email = ViewModel.TextBoxEmailText,
                Birthday = ViewModel.DatePickerBirthdaySelectedDate
            };
            int idNewPlayer = ViewModel.PlayerService.InsertPlayer(playerModel);
            playerModel.Id = idNewPlayer;
            ViewModel.Players.Add(playerModel);
            

            ViewModel.WidthGridAddPlayer = new GridLength(0, GridUnitType.Star);
            ViewModel.StateMainDataGrid = true;

            ViewModel.IsEnabledButtonAddSave = false;
            ViewModel.VisibilityButtonAddSave = Visibility.Hidden;
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
            ViewModel.SelectedPlayer = (PlayerModel)button.DataContext;
            ViewModel.Teams = new ObservableCollection<TeamModel>(ViewModel.PlayerService.GetTeamsByPlayerId(ViewModel.SelectedPlayer.Id));
            ViewModel.WidthGridPlayerInfo = new GridLength(1, GridUnitType.Star);
            ViewModel.StateMainDataGrid = false;
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            PlayerModel player = (PlayerModel)button.DataContext;
            ViewModel.Players.Remove(player);
            ViewModel.PlayerService.DeleteById(player.Id);

        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            ViewModel.SelectedPlayer = (PlayerModel)button.DataContext;
            ViewModel.IsEnabledButtonEditSave = true;
            ViewModel.VisibilityButtonEditSave = Visibility.Visible;

            ViewModel.WidthGridAddPlayer = new GridLength(1, GridUnitType.Star);
            ViewModel.TextBoxFirstNameText = ViewModel.SelectedPlayer.FirstName;
            ViewModel.TextBoxLastNameText = ViewModel.SelectedPlayer.LastName;
            ViewModel.TextBoxNickNameText = ViewModel.SelectedPlayer.NickName;
            ViewModel.TextBoxEmailText = ViewModel.SelectedPlayer.Email;
            ViewModel.DatePickerBirthdaySelectedDate = ViewModel.SelectedPlayer.Birthday;
            
            ViewModel.StateMainDataGrid = false;

        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.WidthGridPlayerInfo = new GridLength(0, GridUnitType.Star);
            ViewModel.StateMainDataGrid = true;
        }

        private void ButtonBackSavePlayer_Click(object sender, RoutedEventArgs e)
        {

            ViewModel.WidthGridAddPlayer = new GridLength(0, GridUnitType.Star);
            ViewModel.StateMainDataGrid = true;
            ViewModel.VisibilityButtonAddSave = Visibility.Hidden;
            ViewModel.VisibilityButtonEditSave = Visibility.Hidden;
            ViewModel.IsEnabledButtonAddSave = false;
            ViewModel.IsEnabledButtonEditSave = false;

        }
    }
}
