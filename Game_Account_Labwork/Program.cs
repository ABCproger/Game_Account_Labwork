using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Game_Account_Labwork.appContext;
using Game_Account_Labwork.Entities;
using Game_Account_Labwork.Entities.GameAccounts;
using Microsoft.EntityFrameworkCore;

namespace EF_Labwork
{


    class Program
    {
        static void Main()
        {
            using (var _context = new ApplicationContext())
            {

                GameAccount player1 = new PremiumGameAccount { UserName = "Valera", CurrentRating = 1000 };
                GameAccount player2 = new TrainingGameAccount { UserName = "Vova", CurrentRating = 1200 };
                GameAccount player3 = new GameAccount { UserName = "Default", CurrentRating = 100 };
                _context.GameAccounts.Add(player1);
                _context.GameAccounts.Add(player2);
                _context.GameAccounts.Add(player3);
                _context.SaveChanges();

  
                player1.WinGame(player2.UserName, 50);
                player2.LoseGame(player1.UserName, 50);

                player1.LoseGame(player2.UserName, 30);
                player2.WinGame(player1.UserName, 300);

                player3.WinGame(player1.UserName, 30);
                player3.LoseGame(player1.UserName, 100);

                _context.SaveChanges();

                player1.GetStats();
                player2.GetStats();
                player3.GetStats();
            }
        }
    }
}
