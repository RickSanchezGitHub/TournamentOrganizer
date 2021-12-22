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
using TournamentOrganizer.BusinessLayer.Configuration;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Tabs
{
    /// <summary> 
    /// Логика взаимодействия для TabItemGame.xaml 
    /// </summary> 
    public partial class TabItemGame : TabItem
    {
        //public TabItemGameViewModel ViewModel;
        public TabItemGame()
        {
            InitializeComponent();
           // ViewModel = new TabItemGameViewModel();
            //DataContext = ViewModel;
        }



        //private void ButtonGameDelite_Click(object sender, RoutedEventArgs e)
        //{
        //    var button = (Button)sender;
        //    var game = (GameModel)button.DataContext;
        //    //ViewModel.Games.Remove(game);
        //    //ViewModel.GameService.DeleteGame(game.Id);
            

        //}

        //private void ButtonGameEdit_Click(object sender, RoutedEventArgs e)
        //{

        //    ViewModel.StateButtonCancel = true;
        //    ViewModel.StateDataGrid = false;


        //    var button = (Button)sender;
        //    ViewModel.SelectedGame = (GameModel)button.DataContext;
        //    ViewModel.TextBoxAddGameNameText = ViewModel.SelectedGame.Name;


        //    ViewModel.ButtonAddEditContent = "Сохранить";
        //}

        //private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        //{
        //    if (String.IsNullOrWhiteSpace(ViewModel.TextBoxAddGameNameText))
        //    {
        //        MessageBox.Show("Введите название игры");
        //        return;
        //    }

        //    if (ViewModel.Games.FirstOrDefault(item => item.Name == ViewModel.TextBoxAddGameNameText) != null)
        //    {
        //        MessageBox.Show("Такая игра уже есть");
        //        return;
        //    }

        //    if (ViewModel.ButtonAddEditContent == "Добавить")
        //    {
        //        ViewModel.Games.Add(new GameModel { Name = TextBoxAddGameName.Text });
        //        ViewModel.GameService.InsertGame(TextBoxAddGameName.Text);
        //    }
        //    else if (ViewModel.ButtonAddEditContent == "Сохранить")
        //    {
        //        ViewModel.ButtonAddEditContent = "Добавить";

        //        ViewModel.SelectedGame.Name = ViewModel.TextBoxAddGameNameText;
        //        ViewModel.GameService.UpdateGameName(ViewModel.SelectedGame.Name, ViewModel.SelectedGame.Id);
        //        ViewModel.StateDataGrid = true;

        //    }
        //    ViewModel.TextBoxAddGameNameText = String.Empty;
        //}

        //private void TextBoxAddGameName_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (ViewModel.TextBoxAddGameNameText.Length > 25)
        //    {
        //        MessageBox.Show("Длинное название");
        //        return;
        //    }
        //}

        //private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        //{
        //    ViewModel.ButtonAddEditContent = "Добавить";

        //    ViewModel.StateButtonCancel = false;
        //    ViewModel.TextBoxAddGameNameText = String.Empty;

        //    ViewModel.StateDataGrid = true;
        //}
    }
}