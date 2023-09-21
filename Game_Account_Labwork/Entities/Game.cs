using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Game_Account_Labwork.Entities
{
    public class Game
    {
        public int GameId { get; set; }
        public int GameRating { get; set; }
        public string? FirstGamer { get; set; }
        public string? SecondGamer { get; set; }
        public string? Winner { get; set; }

        public Game (string? firstGamer, string? secondGamer)
        {
            FirstGamer = firstGamer;
            SecondGamer = secondGamer;
        }

        public int setGameRating()
        {
            Console.WriteLine("Please, choose rating of this game: ");
            int gameRating = int.Parse(Console.ReadLine());
            GameRating = gameRating;

            if (GameRating < 0)
            {
                throw new Exception("the rating of this game cannot be less than 0");
            }

            return gameRating;
        }

        public void gameResult(string? winner)
        {
            Winner = winner;
        }
    }
}
