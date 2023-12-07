using Game_Account_Labwork.appContext;
using Game_Account_Labwork.Entities.Games;
using Game_Account_Labwork.Intefaces;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Account_Labwork.Repositories
{
    public class GameRepository :IGameRepository
    {
        private readonly ApplicationContext _context;
        public GameRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void AddGame(Game game)
        {
            _context.Game.Add(game);
        }

        public void DeleteGame(int gameId)
        {
            var game = _context.Game.Find(gameId);
            if (game != null)
            {
                _context.Game.Remove(game);
            }
        }

        public List<Game> GetAllGames()
        {
           return _context.Game.ToList();
        }
        public List<Game> GetAllGamesByGameAccountId(int gameAccountId)
        {
            return _context.Game
                .Where(game => game.GameAccountId == gameAccountId)
                .ToList();
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public Game UpdateGame(Game updatedGame)
        {
            var existingGame = _context.Game.Find(updatedGame.Id);

            if (existingGame != null)
            {
                existingGame.FirstPlayer = updatedGame.FirstPlayer;
                existingGame.SecondPlayer = updatedGame.SecondPlayer;
                existingGame.Winner = updatedGame.Winner;
                existingGame.Rating = updatedGame.Rating;
                existingGame.GameAccountId = updatedGame.GameAccountId;
            }

            return existingGame;
        }
    }
}
