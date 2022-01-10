﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentOrganizer.BusinessLayer.Models
{
    public interface IParticipant
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
