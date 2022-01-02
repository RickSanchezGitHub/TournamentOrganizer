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
using TournamentOrganizer.UI.ViewModels;

namespace TournamentOrganizer.UI.Tabs
{
    /// <summary> 
    /// Логика взаимодействия для TabItemGame.xaml 
    /// </summary> 
    public partial class TabItemGame : TabItem
    {
        private TabItemGameViewModel _viewModel;

        public TabItemGame()
        {
            InitializeComponent();
            _viewModel = new();
            DataContext = _viewModel;

        }
    }
}