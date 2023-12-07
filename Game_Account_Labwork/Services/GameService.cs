using Game_Account_Labwork.appContext;
using Game_Account_Labwork.Entities.GameAccounts;
using Game_Account_Labwork.Entities.Games;
using Game_Account_Labwork.Factories;
using Game_Account_Labwork.Intefaces;
using Game_Account_Labwork.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace Game_Account_Labwork.Services
{
    public class GameService :IGameService
    {
        //private readonly IGameService _gameService;
        private readonly IGameRepository _gameRepository;
        public GameService(ApplicationContext context)
        {
            _gameRepository = new GameRepository(context);
            //_gameService = new GameService(context);
        }
        public List<Game> CreateStandardGame(GameAccount gameAccount1, GameAccount gameAccount2)
        {
            GameFactory gameFactory = new GameFactory();
            var games = gameFactory.CreateStandardGame(gameAccount1, gameAccount2);

            //_gameRepository.AddGames(games);

            //_gameRepository.Save();

            return games;
        }

        public List<Game> CreateTrainingGame(GameAccount gameAccount1, GameAccount gameAccount2)
        {
            GameFactory gameFactory = new GameFactory();
            var game = gameFactory.CreateTrainingGame(gameAccount1, gameAccount2);
            //_gameRepository.AddGames(game);
            //_gameRepository.Save();

            return game;
        }

        public List<Game> GetAllGames()
        {
            return _gameRepository.GetAllGames();
        }

        public void SaveGameResults(Game game)
        {
            _gameRepository.AddGame(game);
            _gameRepository.Save();
        }

       
    }
}
