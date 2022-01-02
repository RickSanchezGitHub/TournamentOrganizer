using System.Collections.Generic;
using TournamentOrganizer.BusinessLayer.Models;

namespace TournamentOrganizer.BusinessLayer.Configuration
{
    public interface IGameService
    {
        void DeleteGame(int id);
        List<GameModel> GetAllGames();
        int InsertGame(string nameGame);
        void UpdateGameName(string newNameGame, int id);
    }
}