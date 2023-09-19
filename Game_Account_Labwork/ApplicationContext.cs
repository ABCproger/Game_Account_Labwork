using EF_Labwork;
using Game_Account_Labwork.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Account_Labwork
{
    public class ApplicationContext : DbContext
    {
        public DbSet<GameAccount> GameAccounts => Set<GameAccount>();
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-MIR7NIF;Initial Catalog=Test_DB;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
