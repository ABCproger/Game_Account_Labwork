﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Account_Labwork.Entities.Games
{
    public class NoRatingGame : Game
    {
        public override int RatingCalculation()
        {
            throw new NotImplementedException();
        }
    }
}
