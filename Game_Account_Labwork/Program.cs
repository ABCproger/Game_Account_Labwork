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
                //GameAccount standardPlayer = new GameAccount { UserName = "Default", CurrentRating = 100 };

                GameFactory gameFactory = new GameFactory();
                //var standartGame = gameFactory.CreateStandardGame(standardPlayer.UserName,trainingPlayer.UserName);
                //var TrainingGame = gameFactory.CreateTrainingGame(standardPlayer.UserName, trainingPlayer.UserName);
                var trainingGame = gameFactory.CreateTrainingGame(premiumPlayer.UserName, trainingPlayer.UserName);
                _context.GameAccounts.Add(premiumPlayer);
                _context.GameAccounts.Add(trainingPlayer);
                //_context.GameAccounts.Add(standardPlayer);

                _context.SaveChanges();
                premiumPlayer.LoseGame(trainingGame);
                //trainingPlayer.WinGame(TrainingGame);
                //standardPlayer.LoseGame(TrainingGame);
                _context.SaveChanges();

                premiumPlayer.GetStats();
                trainingPlayer.GetStats();
                //standardPlayer.GetStats();
            }
        }
    }
}
