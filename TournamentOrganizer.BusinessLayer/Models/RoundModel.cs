using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentOrganizer.BusinessLayer.Models
{
    public class RoundModel
    {
        public RoundModel(List<IParticipant> roundParticipants, int numberParticipantsInMatch)
        {
            
        }

        public int RoundNumber { get; set; }
        public List<MatchModel> Matchs { get; set; }

        public List<MatchModel> DistribiteParticipants(List<IParticipant> roundParticipants)
        {
            return Matchs;
        }


    }
}
