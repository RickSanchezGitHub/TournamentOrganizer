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
using TournamentOrganaizer.DataLayer;
using TournamentOrganaizer.DataLayer.Entities;
using TournamentOrganaizer.DataLayer.Repositories;


namespace TournamentOrganizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var test = new TournamentRepository();
            test.TournamentInsert(new Tournament() { Id = 1, Name = "TestInsert", StartDate = new DateTime(1999, 10, 2), CloseDate = new DateTime(1999, 10, 2) , Game = new Game() { Id = 3, Name = "132"} });
            //var tetsRes = test.GameInsert("NewGame") ;
            int e = 3;

        }
    }
}
