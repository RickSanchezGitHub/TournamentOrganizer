using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.BusinessLayer.Models;

namespace TournamentOrganizer.UI.VeiwModels
{
    public class TournamentViewModel
    {
        public List<TournamentModel> Tournaments { get; set; }
    }
}
