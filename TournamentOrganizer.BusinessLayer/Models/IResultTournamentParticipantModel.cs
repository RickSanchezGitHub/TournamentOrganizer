using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TournamentOrganizer.BusinessLayer.Models
{
    public interface IResultTournamentParticipantModel
    {
        int Id { get; set; }
        int NumberMatch { get; set; }
        int NumberRound { get; set; }
        int Result { get; set; }
        TournamentModel Tournament { get; set; }

        IParticipant Participant { get; set; }

        event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string prop = "");
    }
}