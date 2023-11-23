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

        public override int PointsCalculation(int rating)
        {
            const int premiumMultipier = 2;
            return rating * premiumMultipier;
        }
        public override void LoseGame(Game game)
        {
            const int losePremiumMultiplier = 4;
            ValidateRating(game.Rating);
            CurrentRating -= PointsCalculation(game.Rating) / losePremiumMultiplier;
            if (game.FirstPlayer == UserName)
            {
                game.Winner = game.SecondPlayer;
            }
            else
            {
                game.Winner = game.FirstPlayer;
            }
            Games.Add(game);
        }
    }
}
