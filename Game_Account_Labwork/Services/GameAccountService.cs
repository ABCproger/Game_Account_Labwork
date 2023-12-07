using Game_Account_Labwork.appContext;
using Game_Account_Labwork.Entities.GameAccounts;
using Game_Account_Labwork.Entities.Games;
using Game_Account_Labwork.Factories;
using Game_Account_Labwork.Intefaces;
using Game_Account_Labwork.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Account_Labwork.Services
{
    public class GameAccountService : IGameAccountService
    {
        private readonly IGameAccountRepository _gameAccountRepository;
        private readonly IGameRepository _gameRepository;
        public GameAccountService(ApplicationContext context)
        {
            _gameAccountRepository = new GameAccountRepository(context);
            _gameRepository = new GameRepository(context);
        }

        public GameAccount CreatePremiumAccount(string userName, int currentRating)
        {
            GameAccountFactory gameAccountFactory = new GameAccountFactory();
            var gameAccount = gameAccountFactory.CreatePremiumAccount(userName, currentRating);
            _gameAccountRepository.Add(gameAccount);
            _gameAccountRepository.Save();

            return gameAccount;
        }

        public GameAccount CreateStandardAccount(string userName, int currentRating)
        {
            GameAccountFactory gameAccountFactory = new GameAccountFactory();
            var gameAccount = gameAccountFactory.CreateStandardAccount(userName, currentRating);
            _gameAccountRepository.Add(gameAccount);
            _gameAccountRepository.Save();

            return gameAccount;
        }

        public GameAccount CreateTrainingAccount(string userName, int currentRating)
        {
            GameAccountFactory gameAccountFactory = new GameAccountFactory();
            var gameAccount = gameAccountFactory.CreateTrainingAccount(userName, currentRating);
            _gameAccountRepository.Add(gameAccount);
            _gameAccountRepository.Save();

            return gameAccount;
        }

        public List<GameAccount> GetAllGameAccounts()
        {
            return _gameAccountRepository.GetAll();
        }

        public List<Game> GetAllGamesByGameAccountId(int gameAccountId)
        {
            return _gameRepository.GetAllGamesByGameAccountId(gameAccountId);
        }

        public GameAccount GetGameAccountById(int gameAccountId)
        {
            return _gameAccountRepository.GetAccountById(gameAccountId);
        }
    }
}
