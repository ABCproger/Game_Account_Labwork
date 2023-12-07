using Game_Account_Labwork.Entities.Games;
using Game_Account_Labwork.Intefaces;
using Game_Account_Labwork.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Account_Labwork.Entities.GameAccounts
{
    public class GameAccount
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public int CurrentRating { get; set; }
        public List<Game> Games { get; set; } = new List<Game>();
        public GameAccount(string userName, int currentRating)
        {
            UserName = userName;
            CurrentRating = currentRating;

        }

        public virtual int PointsCalculation(int rating)
        {
            return rating;
        }
        public virtual Game WinGame(Game game)
        {
            ValidateRating(game.Rating);
            CurrentRating += PointsCalculation(game.Rating);
            game.Winner = UserName;

            //Games.Add(new Game { FirstPlayer = game.FirstPlayer, SecondPlayer = game.SecondPlayer, 
            //    Rating = game.Rating, Winner = game.Winner, Id = game.Id, GameAccount = game.GameAccount, 
            //    GameAccountId = game.GameAccountId });
            var gameResult = new Game
            {
                FirstPlayer = game.FirstPlayer,
                SecondPlayer = game.SecondPlayer,
                Rating = game.Rating,
                Winner = game.Winner,
                Id = game.Id,
                GameAccount = game.GameAccount,
                GameAccountId = game.GameAccountId

            };
            return gameResult;
        }

        public virtual Game LoseGame(Game game)
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
            //Games.Add(new Game
            //{
            //    FirstPlayer = game.FirstPlayer,
            //    SecondPlayer = game.SecondPlayer,
            //    Rating = game.Rating,
            //    Winner = game.Winner,
            //    Id = game.Id,
            //    GameAccount = game.GameAccount,
            //    GameAccountId = game.GameAccountId
            //});
            var gameResult = new Game
            {
                FirstPlayer = game.FirstPlayer,
                SecondPlayer = game.SecondPlayer,
                Rating = game.Rating,
                Winner = game.Winner,
                Id = game.Id,
                GameAccount = game.GameAccount,
                GameAccountId = game.GameAccountId

            };
            return gameResult;
        }

        public void GetStats()
        {
            Console.WriteLine($"Stats for {UserName}:");
            Console.WriteLine("Opponent\tWinner\t\tRating\t\tGame Index");
            string opponentName = null;

            for (int i = 0; i < Games.Count; i++)
            {
                Game game = Games[i];
                if (game.FirstPlayer == UserName)
                {
                    opponentName = game.SecondPlayer;
                }
                else
                {
                    opponentName = game.FirstPlayer;
                }
                Console.WriteLine($"{opponentName}\t\t{(game.Winner)}\t\t{game.Rating}\t\t{i + 1}");
            }

            Console.WriteLine("GamesCount: " + Games.Count);
            Console.WriteLine();
        }

        protected void ValidateRating(int rating)
        {
            if (rating < 1)
            {
                throw new ArgumentException("Rating cannot be negative.");
            }
        }
    }
}
