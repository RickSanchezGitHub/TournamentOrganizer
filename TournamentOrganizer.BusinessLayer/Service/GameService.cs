using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganaizer.DataLayer.Repositories;
using TournamentOrganizer.BusinessLayer.Models;

namespace TournamentOrganizer.BusinessLayer.Configuration
{
    public class GameService
    {
        private readonly GameRepository _gameRepository;
        public GameService()
        {
            _gameRepository = new GameRepository();
        }

        public List<GameModel> GetAllGames()
        {
            var games = _gameRepository.GameSelectByAll();
            return CustomMapper.GetInstance().Map<List<GameModel>>(games);
        }

        public void DeleteGame(int id)
        {
            _gameRepository.GameDeleteById(id);
        }

        public int InsertGame(string nameGame)
        {
           return _gameRepository.GameInsert(nameGame);
        }

        public void UpdateGameName(string newNameGame, int id)
        {
            _gameRepository.GameUpdate(id, newNameGame);
        }

    }
}
