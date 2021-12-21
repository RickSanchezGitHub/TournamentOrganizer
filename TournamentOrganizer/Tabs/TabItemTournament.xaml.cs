using Helpers;
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
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Tabs
{
    /// <summary>
    /// Interaction logic for TabItemTournament.xaml
    /// </summary>
    public partial class TabItemTournament : TabItem
    {
        private const double ColumnVisibilityOn = 40;
        private const double ColumnVisibilityOff = 0;


        public TabItemTournament()
        {
            InitializeComponent();
            //DataContext = new TabItemTournamentsViewModel();
            
        }

        private void UpdateViewModel()
        {

        }

        private void ButtonDataGridTournamentsDeleteClick(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonTournamentsAddClick(object sender, RoutedEventArgs e)
        {
            UIHelpers.ChangeWidthGridColumns(columnsSaveUpdate, ColumnVisibilityOn);
            ButtonUpdate.Visibility = Visibility.Collapsed;
            ButtonSave.Visibility = Visibility.Visible;
        }

        private void ButtonTournamentsBackClick(object sender, RoutedEventArgs e)
        {
            UIHelpers.ChangeWidthGridColumns(columnsSaveUpdate, ColumnVisibilityOff);
        }

        private void ButtonTournamentsSaveClick(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDataGridTournamentsUpdateClick(object sender, RoutedEventArgs e)
        {
            UIHelpers.ChangeWidthGridColumns(columnsSaveUpdate, ColumnVisibilityOn);
            ButtonUpdate.Visibility = Visibility.Visible;
            ButtonSave.Visibility = Visibility.Collapsed;
        }

        private void ButtonTournamentsUpdateClick(object sender, RoutedEventArgs e)
        {

            UIHelpers.ChangeWidthGridColumns(columnsSaveUpdate, ColumnVisibilityOff);
       
        }

        private void ButtonTournamentsOpenParticipants(object sender, RoutedEventArgs e)
        {
            DataGridTournaments.Visibility = Visibility.Collapsed;
            DataGridParticipants.Visibility = Visibility.Visible;
            ButtonCloseParticipants.Visibility = Visibility.Visible;
        }

        private void ButtonParticipantsCloseClick(object sender, RoutedEventArgs e)
        {
            DataGridTournaments.Visibility = Visibility.Visible;
            DataGridParticipants.Visibility = Visibility.Collapsed;
            ButtonCloseParticipants.Visibility = Visibility.Collapsed;
        }
    }
}
