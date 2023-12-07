using Game_Account_Labwork.appContext;
using Game_Account_Labwork.Entities.GameAccounts;
using Game_Account_Labwork.Intefaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Account_Labwork.Repositories
{
    public class GameAccountRepository :IGameAccountRepository
    {
        private readonly ApplicationContext _context;
        public GameAccountRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<GameAccount> GetAll()
        {
            return _context.GameAccounts.ToList();
        }

        public void Add(GameAccount gameAccount)
        {
            _context.GameAccounts.Add(gameAccount);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
