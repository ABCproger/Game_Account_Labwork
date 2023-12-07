using Game_Account_Labwork.Entities.GameAccounts;
using Game_Account_Labwork.Entities.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Account_Labwork.Intefaces
{
    public interface IGameRepository
    {
        List<Game> GetAllGames();
        List<Game> GetAllGamesByGameAccountId(int gameAccountId);
        void AddGame(Game game);
        void Save();
        Game UpdateGame(Game game);
        void DeleteGame(int gameAccountId);

    }
}
