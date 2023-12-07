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
        Game CreatePremiumAccount(string player1Username, string player2Username);
        Game CreateStandardGame(string player1Username, string player2Username);
        Game CreateTrainingGame(string player1Username, string player2Username);
        void SaveGameResults(Game game);
    }

}
