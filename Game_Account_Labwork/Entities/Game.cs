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

        public void startGame(GameAccount player1, GameAccount player2)
        {
            int rating;
            Random random = new Random();
            Game gameInfo = new Game(player1.UserName, player2.UserName);
            rating = gameInfo.setGameRating();

            if (random.Next(0,10) > 5)
            {
                player1.WinGame(player2.UserName, rating);
                player2.LoseGame(player1.UserName, rating);
                gameInfo.gameResult(player1.UserName);
            }
            else
            {
                player2.WinGame(player1.UserName, rating);
                player1.LoseGame(player2.UserName, rating);
                gameInfo.gameResult(player2.UserName);
            }

            gameInfo.saveToDb(gameInfo, player1, player2);

        }
        private void gameResult(string? winner)
        {
            Winner = winner;
        }
        private void saveToDb(Game gameInfo, GameAccount player1, GameAccount player2)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.GameAccounts.AddRange(player1, player2);
                db.Game.Add(gameInfo);
                db.SaveChanges();
            }
        }


        private int setGameRating()
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
        
    }
}
