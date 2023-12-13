using Game_Account_Labwork.appContext;
using Game_Account_Labwork.Entities.GameAccounts;
using Game_Account_Labwork.Entities.Games;
using Game_Account_Labwork.Intefaces;
using Game_Account_Labwork.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Account_Labwork.Entities.Managers
{
    public class ProgramManager : IProgramManager
    {
        private readonly IGameAccountService _gameAccountService;
        private readonly IGameService _gameService;
        public ProgramManager(ApplicationContext context)
        {
            _gameAccountService = new GameAccountService(context);
            _gameService = new GameService(context);
        }
        public void AddPlayer(string playerName,int currentRating, string accountType)
        {
            if(accountType == "premium")
            {
                _gameAccountService.CreatePremiumAccount(playerName, currentRating);
            }
            else if(accountType == "standard")
            {
                _gameAccountService.CreateStandardAccount(playerName, currentRating);
            }
            else if(accountType == "training")
            {
                _gameAccountService.CreateTrainingAccount(playerName, currentRating);
            }
        }

        public void DisplayCommands()
        {
            throw new NotImplementedException();
        }

        public void DisplayGames()
        {
            var gamesList = _gameService.GetAllGames();
            foreach (var game in gamesList)
            {
                Console.WriteLine($"id:{game.Id} first player:{game.FirstPlayer} second player:{game.SecondPlayer} Winner:{game.Winner} gameRating: {game.Rating}");
            }
            Console.WriteLine($"count of games: {gamesList.Count}");
        }

        public void DisplayPlayers()
        {
            var gameAccountsList = _gameAccountService.GetAllGameAccounts();
            foreach (var account in gameAccountsList)
            {
                Console.WriteLine($"{account.Id} {account.UserName}     {account.CurrentRating}");
            }
            Console.WriteLine($"Total count of gameAccounts: {gameAccountsList.Count}");
        }

        public void DisplayPlayerStats()
        {
            int playerId;
            while (true)
            {
                Console.Write("Please enter the player's ID for showing player stats: ");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out playerId))
                {
                    var gameAccount = _gameAccountService.GetGameAccountById(playerId);
                    if(gameAccount != null)
                    {
                        gameAccount.Games = _gameAccountService.GetAllGamesByGameAccountId(gameAccount.Id);
                        gameAccount.GetStats();
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid player ID.");
                }
            }
        }

        public void PlayGame()
        {
            List<GameAccount> gameAccounts = GetPlayersForGame();
            string gameType = ChooseGameType();
            if(gameType == "training")
            {
                var games = _gameService.CreateTrainingGame(gameAccounts[0], gameAccounts[1]);
                var gameResult1 = gameAccounts[0].WinGame(games[0]);
                var gameResult2 = gameAccounts[1].LoseGame(games[1]);
                _gameService.SaveGameResults(gameResult1);
                _gameService.SaveGameResults(gameResult2);
            }
            else if(gameType == "standard")
            {
                var games = _gameService.CreateStandardGame(gameAccounts[0], gameAccounts[1]);
                var gameResult1 = gameAccounts[0].WinGame(games[0]);
                var gameResult2 = gameAccounts[1].LoseGame(games[1]);
                _gameService.SaveGameResults(gameResult1);
                _gameService.SaveGameResults(gameResult2);
            }
        }
        private List<GameAccount> GetPlayersForGame()
        {
            List<GameAccount> players = new List<GameAccount>();

            while (players.Count < 2)
            {
                Console.Write($"Please enter ID for {(players.Count == 0 ? "first" : "second")} player: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int playerId))
                {
                    var player = _gameAccountService.GetGameAccountById(playerId);

                    if (player != null)
                    {
                        players.Add(player);
                    }
                    else
                    {
                        Console.WriteLine($"Player with ID {playerId} not found. Please enter a valid ID.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer ID.");
                }
            }

            return players;
        }

        private string ChooseGameType()
        {
            int gameTypeId;
            while (true)
            {

                Console.Write("Please, choose gametype: \n 1: training\n 2: standard\n");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out gameTypeId))
                {
                    if(userInput == "1")
                    {
                        return "training";
                    }
                    else if(userInput == "2")
                    {
                        return "standard";
                    }

                }
                else
                {
                    Console.WriteLine("Invalid input. Please choose a valid gameTypeId.");
                }
            }
        }

    }
}
