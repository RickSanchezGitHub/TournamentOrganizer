using System.Collections.Generic;
using TournamentOrganaizer.DataLayer.Entities;

namespace TournamentOrganaizer.DataLayer.Repositories
{
    public interface ITournamentRepository
    {
        void TournamentDeleteById(int id);
        int TournamentInsert(Tournament tournament);
        List<Tournament> TournamentSelectAll();
        Tournament TournamentSelectById(int id);
        void TournamentUpdateById(Tournament tournament);
    }
}