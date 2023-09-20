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
        
        public void WnGame (string? opponentName, int rating)
        {
            CurrentRating += rating;
        }

        public void LoseGame(string? opponentName, int rating)
        {
            CurrentRating -= rating;
        }

        public void GetStats()
        {

        }
    }
}
