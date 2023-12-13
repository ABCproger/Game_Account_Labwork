using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Account_Labwork.Intefaces
{
    public interface IProgramManager
    {
        void DisplayCommands(); 
        void DisplayPlayers(); 
        void AddPlayer(string playerName,int currentRating, string accountType); 
        void DisplayPlayerStats(); 
        void PlayGame();
        void DisplayGames();
    }

}
