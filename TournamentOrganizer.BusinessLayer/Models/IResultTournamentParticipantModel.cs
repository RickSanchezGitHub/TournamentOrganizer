using System.ComponentModel;

namespace TournamentOrganizer.BusinessLayer.Models
{
    public interface IResultTournamentParticipantModel
    {
        int Id { get; set; }
        int? NumberMatch { get; set; }
        int? NumberRound { get; set; }
        int? Result { get; set; }
        TournamentModel Tournament { get; set; }
    }
}