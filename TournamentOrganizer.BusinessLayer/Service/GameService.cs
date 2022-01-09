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
            var games = _gameRepository.GameSelectAll();
            return CustomMapper.GetInstance().Map<List<GameModel>>(games);
        }

        public void DeleteGame(int id)
        {
            _gameRepository.GameDeleteById(id);
        }

        public int InsertGame(string nameGame, string description)
        {
            return _gameRepository.GameInsert(nameGame, description);
        }

        public void UpdateGameName(int id, string newNameGame, string description)
        {
            _gameRepository.GameUpdate(id, newNameGame, description);
        }

        public GameModel GameSelectById(int gameId)
        {
            var game = _gameRepository.GameSelectById(gameId);
            return CustomMapper.GetInstance().Map<GameModel>(game);
        }
    }
}