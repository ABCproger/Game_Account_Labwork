using Game_Account_Labwork.Entities.GameAccounts;
using Game_Account_Labwork.Entities.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Account_Labwork.Intefaces
{
    public interface IGameService
    {
        
        List<Game> CreateStandardGame(GameAccount gameAccount1, GameAccount gameAccount2);
        List<Game> CreateTrainingGame(GameAccount gameAccount1, GameAccount gameAccount2);
        void SaveGameResults(List<Game> game);
    }

}
