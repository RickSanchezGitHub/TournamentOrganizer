using System.Collections.Generic;
using TournamentOrganizer.BusinessLayer.Configuration;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.DataLayer.Entities;
using TournamentOrganizer.DataLayer.Repositories;

namespace TournamentOrganizer.BusinessLayer.Service.PlayerService
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService()
        {
            _playerRepository = new PlayerRepository();
        }

        public List<PlayerModel> GetAll()
        {
            var players = _playerRepository.GetAll();
            return CustomMapper.GetInstance().Map<List<PlayerModel>>(players);
        }

        public PlayerModel GetById(int id)
        {
            var players = _playerRepository.GetById(id);
            return CustomMapper.GetInstance().Map<PlayerModel>(players);
        }

        public void Delete(int id)
        {
            _playerRepository.Delete(id);
        }

        public int Insert(PlayerModel playerModel)
        {
            var player = CustomMapper.GetInstance().Map<Player>(playerModel);
            int id = _playerRepository.Insert(player);
            return id;
        }

        public void Update(int id, PlayerModel playerModel)
        {
            var player = CustomMapper.GetInstance().Map<Player>(playerModel);
            _playerRepository.Update(id, player);
        }

    }
}
