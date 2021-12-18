﻿using System;
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
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Tabs
{
    /// <summary>
    /// Interaction logic for TabItemTournament.xaml
    /// </summary>
    public partial class TabItemTournament : TabItem
    {
        private readonly TournamentService _tournamentService;
        public TabItemTournament()
        {
            InitializeComponent();
            _tournamentService = new TournamentService();
            var vm = new TournamentViewModel();
            vm.Tournaments = _tournamentService.GetAllTournaments();
            DataContext = vm;
        }
    }
}
