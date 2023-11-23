using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Account_Labwork.Entities
{
    public class TrainingGameAccount : GameAccount
    {
        public override int RatingCalculation(int rating)
        {
            return base.RatingCalculation(rating);
        }
        public override void LoseGame(string opponentName, int rating)
        {
            ValidateRating(rating);
            Games.Add(new Game { OpponentName = opponentName, IsWin = false, Rating = rating });
        }
        public override void WinGame(string opponentName, int rating)
        {
            ValidateRating(rating);
            Games.Add(new Game { OpponentName = opponentName, IsWin = true, Rating = rating });
        }
    }
}
