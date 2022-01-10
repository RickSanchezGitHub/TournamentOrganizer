using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TournamentOrganizer.BusinessLayer.Models
{
    public class ParticipantTournamentResult : BaseModel
    {
        public IParticipant Participant { get; set; }

        public ParticipantTournamentResult(IParticipant participant)
        {
            Participant = participant;
        }

        private int _score;
        public int Score
        {
            get { return _score; }
            set
            {
                _score = value;
                OnPropertyChanged(nameof(Score));
            }
        }

    }
}
