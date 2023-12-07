using Game_Account_Labwork.appContext;
using Game_Account_Labwork.Entities.Games;
using Game_Account_Labwork.Intefaces;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Account_Labwork.Repositories
{
    public class GameRepository :IGameRepository
    {
        private readonly ApplicationContext _context;
        public GameRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void AddGame(Game game)
        {
            _context.Game.Add(game);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
