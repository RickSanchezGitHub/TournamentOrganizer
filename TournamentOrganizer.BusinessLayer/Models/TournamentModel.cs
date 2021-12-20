﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentOrganizer.BusinessLayer.Models
{
    public class TournamentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CloseDate { get; set; }
        public GameModel Game { get; set; }

    }
}
