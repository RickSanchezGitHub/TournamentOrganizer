using System.Collections.Generic;
using TournamentOrganizer.BusinessLayer.Models;

namespace TournamentOrganizer.BusinessLayer.Service
{
    public interface IPlayerService
    {
        void DeleteById(int id);
        List<PlayerModel> GetAll();
        PlayerModel GetById(int id);
        List<TeamModel> GetTeamsByPlayerId(int playerId);
        int InsertPlayer(PlayerModel playerModel);
        void PlayerUpdate(int id, PlayerModel playerModel);
    }
}