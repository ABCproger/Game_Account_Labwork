using Game_Account_Labwork.appContext;
using Game_Account_Labwork.Entities.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Account_Labwork.Entities.GameAccounts
{
    public class TrainingGameAccount : GameAccount
    {
        public override int PointsCalculation(int rating)
        {
            return 0;
        }
        public override void LoseGame(Game game)
        {
            ValidateRating(game.Rating);
            CurrentRating -= PointsCalculation(game.Rating);
            if (game.FirstPlayer == UserName)
            {
                game.Winner = game.SecondPlayer;
            }
            else
            {
                game.Winner = game.FirstPlayer;
            }
            Games.Add(new Game { FirstPlayer = game.FirstPlayer, SecondPlayer = game.SecondPlayer, Rating = game.Rating, Winner = game.Winner, Id = game.Id, GameAccount = game.GameAccount, GameAccountId = game.GameAccountId });

        }
        public override void WinGame(Game game)
        {

            ValidateRating(game.Rating);
            CurrentRating = PointsCalculation(game.Rating);
            game.Winner = UserName;
            //Games.Add(game);
            Games.Add(new Game { FirstPlayer = game.FirstPlayer,SecondPlayer = game.SecondPlayer, Rating = game.Rating, Winner = game.Winner, Id = game.Id, GameAccount = game.GameAccount, GameAccountId = game.GameAccountId});
        }
    }
}
