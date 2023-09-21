using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Game_Account_Labwork;
using Game_Account_Labwork.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_Labwork
{


    internal class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                GameAccount player1 = new GameAccount("Alice", 100);
                GameAccount player2 = new GameAccount("Tom", 100);
                
                Game game1 = new Game(player1.UserName, player2.UserName);
                int rating = game1.setGameRating();

                player1.WinGame(player2.UserName, rating);
                player2.LoseGame(player1.UserName, rating);
                game1.gameResult(player1.UserName);

                db.GameAccounts.AddRange(player1, player2);
                db.Game.Add(game1);
                db.SaveChanges();

            }
        }

    }
}
