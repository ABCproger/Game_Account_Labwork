using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Account_Labwork.Entities.Games
{
    [Table("Games")]
    public class TrainingGame : Game
    {
        public TrainingGame(string firstPlayer, string secondPlayer)
        {
            Rating = RatingCalculation();
            FirstPlayer = firstPlayer;
            SecondPlayer = secondPlayer;
            Winner = "Winner not undefined";
        }
        public override int RatingCalculation()
        {
            return 1;
        }
    }
}
