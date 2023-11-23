using Game_Account_Labwork.Entities.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Account_Labwork.Entities.GameAccounts
{
    public class PremiumGameAccount : GameAccount
    {

        public override int RatingCalculation(int rating)
        {
            const int premiumMultipier = 2;
            return rating * premiumMultipier;
        }
        public override void LoseGame(string opponentName, int rating)
        {
           const int losePremiumMultiplier = 4;
            ValidateRating(rating);
            CurrentRating -= rating / losePremiumMultiplier;
            Games.Add(new Game { OpponentName = opponentName, IsWin = false, Rating = rating });
        }
    }
}
