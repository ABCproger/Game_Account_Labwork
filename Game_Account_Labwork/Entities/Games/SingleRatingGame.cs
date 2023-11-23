using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Account_Labwork.Entities.Games
{
    [Table("Games")]
    public class SingleRatingGame : Game
    {
        public SingleRatingGame(string firstPlayer, string secondPlayer)
        {
            Rating = RatingCalculation();
            FirstPlayer = firstPlayer;
            SecondPlayer = secondPlayer;
        }
        public override int RatingCalculation()
        {
            throw new NotImplementedException();
        }
    }
}
