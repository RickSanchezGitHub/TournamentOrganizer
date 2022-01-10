using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentOrganizer.BusinessLayer.Models
{
    public interface IParticipant 
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
