using Game_Account_Labwork.Entities.Games;
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

        public virtual int RatingCalculation(int rating)
        {
            return rating;
        }
        public virtual void WinGame(string opponentName, int rating)
        {
            ValidateRating(rating);
            CurrentRating += rating;
            Games.Add(new Game { OpponentName = opponentName, IsWin = true, Rating = rating });
        }

        public virtual void LoseGame(string opponentName, int rating)
        {
            ValidateRating(rating);
            CurrentRating -= rating;
            Games.Add(new Game { OpponentName = opponentName, IsWin = false, Rating = rating });
        }

        public void GetStats()
        {
            Console.WriteLine($"Stats for {UserName}:");
            Console.WriteLine("Opponent\tOutcome\t\tRating\t\tGame Index");

            for (int i = 0; i < Games.Count; i++)
            {
                Game game = Games[i];
                Console.WriteLine($"{game.OpponentName}\t\t{(game.IsWin ? "Win" : "Lose")}\t\t{game.Rating}\t\t{i + 1}");
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
