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
using TournamentOrganaizer.DataLayer;
using TournamentOrganaizer.DataLayer.Entities;
using TournamentOrganaizer.DataLayer.Repositories;
using TournamentOrganizer.BusinessLayer.Configuration;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
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
            Random x = new Random();
            InitializeComponent();
            
            
           

            //TournamentModel tour = new TournamentModel();
            //var playerService = new PlayerService();
            //var listPlayers = playerService.GetAll();

            //RoundModel round1 = new RoundModel { RoundNumber = 1 };
            //tour.CreateRound(round1);
            //round1.DistributeParticipantsInFirstRound(listPlayers);
            //var matchs = round1.Matchs;

            //tour.ParticipantsResults = new ObservableCollection<ParticipantTournamentResult>();
            //for (int i = 0; i < listPlayers.Count; i++)
            //{
            //    ParticipantTournamentResult participantTournamentResult = new(listPlayers[i]);
            //    participantTournamentResult.Score = x.Next(3);
            //    tour.ParticipantsResults.Add(participantTournamentResult);
            //}
            //var results = tour.ParticipantsResults.OrderByDescending(item => item.Score);
            //var playerPairs1 = round1.GetAllPlayerPairsInMatchs();

            //var playersExample = new ObservableCollection<PlayerModel>();
            //playersExample.Add(listPlayers[0]);
            //playersExample.Add(listPlayers[1]);
            //var pairs0 = playerPairs1[0];
            //var boolean = playersExample.Intersect(pairs0);
            //int i3 = boolean.Count();

            //var playersSorted = new ObservableCollection<PlayerModel>();
            //foreach (var item in results)
            //{
            //    playersSorted.Add(item.Participant);
            //}

            //RoundModel round2 = new RoundModel();
            //round2.DistributeParticipants(playersSorted, tour);
            //tour.CreateRound(round2);

            //RoundModel round3 = new RoundModel();
            //round3.DistributeParticipants(playersSorted, tour);
        }
    }
}
