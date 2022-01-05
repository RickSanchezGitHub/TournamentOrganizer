using System.Collections.Generic;
using TournamentOrganaizer.DataLayer.Entities;

namespace TournamentOrganaizer.DataLayer.Repositories
{
    public interface IGameRepository
    {
        void GameDeleteById(int id);
        void GameInsert(string name);
        List<Game> GameSelectAll();
        Game GameSelectById(int id);
        void GameUpdate(int id, string name);
    }
}