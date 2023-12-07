using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Game_Account_Labwork.appContext;
using Game_Account_Labwork.Entities;
using Game_Account_Labwork.Entities.GameAccounts;
using Game_Account_Labwork.Entities.Games;
using Game_Account_Labwork.Factories;
using Game_Account_Labwork.Intefaces;
using Game_Account_Labwork.Services;
using Microsoft.EntityFrameworkCore;

namespace EF_Labwork
{


    class Program
    {
        static void Main()
        {
            using (var _context = new ApplicationContext())
            {
                IGameService gameService = new GameService(_context);
                IGameAccountService gameAccountService = new GameAccountService(_context);

                var premiumPlayer = gameAccountService.CreatePremiumAccount("test1", 1000);
                var trainingPlayer = gameAccountService.CreateTrainingAccount("2test2test", 1200);
                //var standardPlayer = gameAccountService.CreateStandardAccount("Defaultplayer test", 100);

                var trainingGame = gameService.CreateTrainingGame(premiumPlayer, trainingPlayer);
                //var standardGame = gameService.CreateStandardGame(standardPlayer.UserName, premiumPlayer.UserName);


                var gameResult1 = trainingPlayer.WinGame(trainingGame[0]);
                var gameResult2 = premiumPlayer.LoseGame(trainingGame[1]);
                gameService.SaveGameResults(gameResult1);
                gameService.SaveGameResults(gameResult2);

                //var gameResult3 = standardPlayer.LoseGame(standardGame);
                //var gameResult4 = premiumPlayer.WinGame(standardGame);
                //gameService.SaveGameResults(gameResult3);
                //gameService.SaveGameResults(gameResult4);


                premiumPlayer.GetStats();
                trainingPlayer.GetStats();
                //standardPlayer.GetStats();
            }
        }
    }
}
