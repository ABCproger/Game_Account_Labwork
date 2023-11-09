using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Account_Labwork.Entities
{
    public class GameAccount
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int CurrentRating { get; set; }
        public List<Game> Games { get; set; } = new List<Game>();

        public int GetGamesCount()
        {
            return Games.Count;
        }
        public void WinGame(string opponentName, int rating)
        {
            ValidateRating(rating);
            CurrentRating += rating;
            Games.Add(new Game { OpponentName = opponentName, IsWin = true, Rating = rating });
        }

        public void LoseGame(string opponentName, int rating)
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
            
            int gamesCount = GetGamesCount();
            Console.WriteLine("GamesCount: " + gamesCount);
            Console.WriteLine();
        }

        private void ValidateRating(int rating)
        {
            if (rating < 1)
            {
                throw new ArgumentException("Rating cannot be negative.");
            }
        }
    }
}
