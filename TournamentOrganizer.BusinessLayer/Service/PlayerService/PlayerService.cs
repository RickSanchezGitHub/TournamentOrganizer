using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.BusinessLayer.Configuration;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.DataLayer.Entities;
using TournamentOrganizer.DataLayer.Repositories;

namespace TournamentOrganizer.BusinessLayer.Service.PlayerService
{
    public class PlayerService : IPlayerService
    {
        private readonly PlayerRepository _playerRepository;
        private readonly TeamPlayerRepository _teamPlayerRepository;
        public PlayerService()
        {
            _playerRepository = new PlayerRepository();
            _teamPlayerRepository = new TeamPlayerRepository();
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
