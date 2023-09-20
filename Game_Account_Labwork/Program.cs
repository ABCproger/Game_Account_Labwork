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

                //GameAccount user1 = new GameAccount { UserName = "Tom", CurrentRating = 33 };
                //GameAccount user2 = new GameAccount { UserName = "Alice", CurrentRating = 26 };

                //Game game1 = new Game { FirstGamer = "Tom", GameRating = 33 };
                
                //db.GameAccounts.AddRange(user1, user2);
                //db.Game.Add(game1);
                db.SaveChanges();

            }
        }

    }
}
