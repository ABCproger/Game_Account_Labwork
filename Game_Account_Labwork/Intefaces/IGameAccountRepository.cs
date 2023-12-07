using Game_Account_Labwork.Entities.GameAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Account_Labwork.Intefaces
{
    public interface IGameAccountRepository
    {
        void Save();
        void Add(GameAccount gameAccount);
        List<GameAccount> GetAll();
        GameAccount GetAccountById(int gameAccountId);
        GameAccount Update(GameAccount game);
        void Delete(int gameAccountId);
    }
}
