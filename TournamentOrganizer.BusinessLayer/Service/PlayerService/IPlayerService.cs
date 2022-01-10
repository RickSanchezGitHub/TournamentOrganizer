using System.Collections.Generic;
using TournamentOrganizer.BusinessLayer.Models;

namespace TournamentOrganizer.BusinessLayer.Service.PlayerService
{
    public interface IPlayerService
    {
        void Delete(int id);
        int Insert(PlayerModel playerModel);
        List<PlayerModel> GetAll();
        PlayerModel GetById(int id);
        void Update(int id, PlayerModel player);

    }
}
