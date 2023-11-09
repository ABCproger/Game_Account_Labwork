using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Account_Labwork.Entities
{
   public class GameAccount
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public int CurrentRating { get; set; }
        public int GamesCount { get; set; }
        
        public GameAccount(string? userName)
        {
            UserName = userName;
            Console.Write("Please, enter your current rating: ");
            CurrentRating = int.Parse(Console.ReadLine());
        }

        public void WinGame (string? opponentName, int rating)
        {
            CurrentRating += rating;

            if (CurrentRating < 1)
            {
                CurrentRating = 1;
            }
        }

        public void LoseGame(string? opponentName, int rating)
        {
            CurrentRating -= rating;

            if(CurrentRating < 1)
            {
                CurrentRating = 1;
            }
        }

        public void GetStats()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var game = db.Game.ToList();
                string? opponentName = "default";
                
                foreach (Game u in game)
                {
                    if(UserName == u.FirstGamer)
                    {
                        opponentName = u.SecondGamer;
                    }
                    else
                    {
                        opponentName = u.FirstGamer;
                    }
                    Console.WriteLine($" Your opponent:{opponentName}, winner: {u.Winner}, Game rating: {u.GameRating}, gameIndex: {u.GameId}");
                }
            }
        }
    }
}
