using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentOrganizer.BusinessLayer.Models
{
    public class RoundModel
    {
        public RoundModel(List<IParticipant> participants, int numberParticipantsInMatch)
        {
            Participants = participants;
        }

        public int RoundNumber { get; set; }
        public List<MatchModel> Matchs { get; set; }

        public List<IParticipant> Participants { get; set; }

        public List<MatchModel> DistribiteParticipants()
        {
            return Matchs;
        }


    }
}
