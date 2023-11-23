using EF_Labwork;
using Game_Account_Labwork.Entities.GameAccounts;
using Game_Account_Labwork.Entities.Games;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Account_Labwork.appContext
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Game> Game => Set<Game>();
        public DbSet<GameAccount>GameAccounts => Set<GameAccount>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-MIR7NIF;Initial Catalog=Test_DB;Integrated Security=True;TrustServerCertificate=True");
        }

    }
}
