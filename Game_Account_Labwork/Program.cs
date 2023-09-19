using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;
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
                //db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                GameAccount user1 = new GameAccount { UserName = "Tom", CurrentRating = 33, GamesCount = 3};
                GameAccount user2 = new GameAccount { UserName = "Alice", CurrentRating = 26, GamesCount = 2 };
                ////    // создаем два объекта User
                //    User Alexander = new User { Name = "ALEXANDER", Age = 19 };
                ////    // добавляем их в бд
                    db.GameAccounts.AddRange(user1,user2);
                    db.SaveChanges();
                //    Console.WriteLine("Объекты успешно сохранены");

                //// получаем объекты из бд и выводим на консоль
                //var users = db.Users.ToList();
                //Console.WriteLine("Список объектов:");
                //foreach (User u in users)
                //{
                //    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                //}
            }
        }

    }
}
