﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Account_Labwork.Entities.Games
{
    [Table("Games")]
    public class StandardGame : Game
    {
        public StandardGame(string firstPlayer, string secondPlayer)
        {
            Rating = RatingCalculation();
            FirstPlayer = firstPlayer;
            SecondPlayer = secondPlayer;
        }
        public override int RatingCalculation()
        {
            Random random = new Random();
            return random.Next(0,100);       
        }
    }
}
