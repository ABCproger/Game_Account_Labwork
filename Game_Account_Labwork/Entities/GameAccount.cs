using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Account_Labwork.Entities
{
   public class GameAccount
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public int CurrentRating { get; set; }
        public int GamesCount { get; set; }
        
        public GameAccount(string? userName, int currentRating)
        {
            UserName = userName;
            CurrentRating = currentRating;
        }
        public void WinGame (string? opponentName, int rating)
        {
            CurrentRating += rating;

            if (CurrentRating < 1)
            {
                CurrentRating = 1;
            }
        }

        public void LoseGame(string? opponentName, int rating)
        {
            CurrentRating -= rating;

            if(CurrentRating < 1)
            {
                CurrentRating = 1;
            }
        }

        public void GetStats()
        {

        }
    }
}
