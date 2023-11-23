using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Game_Account_Labwork.appContext;
using Game_Account_Labwork.Entities;
using Game_Account_Labwork.Entities.GameAccounts;
using Game_Account_Labwork.Entities.Games;
using Game_Account_Labwork.Factories;
using Microsoft.EntityFrameworkCore;

namespace EF_Labwork
{


    class Program
    {
        static void Main()
        {
            using (var _context = new ApplicationContext())
            {

                GameAccount premiumPlayer = new PremiumGameAccount { UserName = "Valera", CurrentRating = 1000 };
                GameAccount trainingPlayer = new TrainingGameAccount { UserName = "Vova", CurrentRating = 1200 };
                GameAccount standardPlayer = new GameAccount { UserName = "Default", CurrentRating = 100 };

                GameFactory gameFactory = new GameFactory();
                var trainingGame = gameFactory.CreateTrainingGame(premiumPlayer.UserName, trainingPlayer.UserName);
                var standardGame = gameFactory.CreateStandardGame(standardPlayer.UserName, premiumPlayer.UserName);
                _context.GameAccounts.AddRange(premiumPlayer,trainingPlayer,standardPlayer);

                _context.SaveChanges();
                trainingPlayer.WinGame(trainingGame);
                premiumPlayer.LoseGame(trainingGame);

                standardPlayer.LoseGame(standardGame);
                premiumPlayer.WinGame(standardGame);

                _context.SaveChanges();

                premiumPlayer.GetStats();
                trainingPlayer.GetStats();
                standardPlayer.GetStats();
            }
        }
    }
}
