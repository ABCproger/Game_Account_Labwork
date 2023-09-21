using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

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

        public void startGame()
        {
            int rating;
            GameAccount player1 = new GameAccount(FirstGamer);
            GameAccount player2 = new GameAccount(SecondGamer);

            Game gameInfo = new Game(player1.UserName, player2.UserName);
            rating = gameInfo.setGameRating();

            player1.WinGame(player2.UserName, rating);
            player2.LoseGame(player1.UserName, rating);
            gameInfo.gameResult(player1.UserName);

            gameInfo.saveToDb(gameInfo, player1, player2);

        }
        public void saveToDb(Game gameInfo, GameAccount player1, GameAccount player2)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.GameAccounts.AddRange(player1, player2);
                db.Game.Add(gameInfo);
                db.SaveChanges();
            }
        }

        public static void printResultOfGames()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var game = db.Game.ToList();
                Console.WriteLine("game list:");
                foreach (Game u in game)
                {
                    Console.WriteLine($"{u.GameId}.{u.FirstGamer} - {u.SecondGamer} Game rating: {u.GameRating} Winner: {u.Winner}");
                }
            }
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
