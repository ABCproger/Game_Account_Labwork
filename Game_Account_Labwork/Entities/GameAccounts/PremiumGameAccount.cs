using Game_Account_Labwork.appContext;
using Game_Account_Labwork.Entities.Games;
using Game_Account_Labwork.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Account_Labwork.Entities.GameAccounts
{
    public class PremiumGameAccount : GameAccount
    {
        public PremiumGameAccount(string userName, int currentRating) : base(userName,currentRating)
        {

        }
        public override int PointsCalculation(int rating)
        {
            const int premiumMultipier = 2;
            return rating * premiumMultipier;
        }
        public override Game LoseGame(Game game)
        {
            const int losePremiumMultiplier = 4;
            ValidateRating(game.Rating);
            CurrentRating -= PointsCalculation(game.Rating) / losePremiumMultiplier;
            DetermineWinner(game);

            // Оновлено: Використовуємо конструктор копіювання або метод копіювання, якщо це потрібно
            //var gameResult = new Game(game);

            return game;
        }
        private void DetermineWinner(Game game)
        {
            if (game.FirstPlayer == UserName)
            {
                game.Winner = game.SecondPlayer;
            }
            else
            {
                game.Winner = game.FirstPlayer;
            }
        }
    }
}
