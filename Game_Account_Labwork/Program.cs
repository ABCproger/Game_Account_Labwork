using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Game_Account_Labwork.appContext;
using Game_Account_Labwork.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_Labwork
{
    

    class Program
    {
        static void Main()
        {
            using (var _context = new ApplicationContext())
            {

                GameAccount player1 = new GameAccount { UserName = "Valera", CurrentRating = 1000 };
                GameAccount player2 = new GameAccount { UserName = "Vova", CurrentRating = 1200 };

                _context.GameAccounts.Add(player1);
                _context.GameAccounts.Add(player2);
                _context.SaveChanges();

  
                player1.WinGame(player2.UserName, 50);
                player2.LoseGame(player1.UserName, 50);

                player1.LoseGame(player2.UserName, 30);
                player2.WinGame(player1.UserName, 30);

                _context.SaveChanges();

                player1.GetStats();
                player2.GetStats();
            }
        }
    }
}
