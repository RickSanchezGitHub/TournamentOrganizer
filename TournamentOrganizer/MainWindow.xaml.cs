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
using TournamentOrganizer.DataLayer.Entities;
using TournamentOrganizer.DataLayer.Repositories;

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

            var repo = new ResultTournamentPlayerRepository();


            Player player = new Player
            {
                Id = 1
            };
            var data = repo.GetPlayerResultsInAllTournaments(player);

            Tournament t = new Tournament { Id = 1 };

            var data2 = repo.GetPlayerResultsInTournament(player, t);

            repo.SetPlayerResultInRoundOfTournament(player, -5, 1, t);
        }
    }
}
