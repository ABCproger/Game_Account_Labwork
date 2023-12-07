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
        public Game CreatePremiumAccount(string player1Username, string player2Username)
        {
            GameFactory gameFactory = new GameFactory();
            var game = gameFactory.CreateSingleRatingGame(player1Username, player2Username);
            //_gameRepository.AddGame(game);
            //_gameRepository.Save();

            return game;
        }

        public Game CreateStandardGame(string player1Username,string player2Username)
        {
            GameFactory gameAccountFactory = new GameFactory();
            var game = gameAccountFactory.CreateStandardGame(player1Username, player2Username);
            //_gameRepository.AddGame(game);
            //_gameRepository.Save();

            return game;
        }

        public Game CreateTrainingGame(string player1Username, string player2Username)
        {
            GameFactory gameAccountFactory = new GameFactory();
            var game = gameAccountFactory.CreateTrainingGame(player1Username, player2Username);
            //_gameRepository.AddGame(game);
            //_gameRepository.Save();

            return game;
        }
        public void SaveGameResults(Game game)
        {
            _gameRepository.AddGame(game);
            _gameRepository.Save();
        }
    }
}
