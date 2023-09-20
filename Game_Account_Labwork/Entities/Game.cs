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
        public int Id { get; set; }
        public int GameRating { get; set; }
        public string? FirstGamer { get; set; }
        public string? SecondGamer { get; set; }

        public Game (string? firstGamer, string? secondGamer, int gameRating)
        {
            FirstGamer = firstGamer;
            SecondGamer = secondGamer;
            GameRating = gameRating;
        }
        public void startGame()
        {

        
        }

        public void setGameRating(int gameRating)
        {

            GameRating = gameRating;
            if (GameRating < 0)
            {
                throw new Exception("the rating of this game cannot be less than 0");
            }
        }
    }
}
