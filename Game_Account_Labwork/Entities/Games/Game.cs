using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Game_Account_Labwork.Entities.GameAccounts;

namespace Game_Account_Labwork.Entities.Games
{
    public class Game
    {
        public int Id { get; set; }
        public string FirstPlayer { get; set; }
        public string SecondPlayer { get; set; }
        public string Winner { get; set; }
        public int Rating { get; set; }
        public int GameAccountId { get; set; }
        public GameAccount GameAccount { get; set; }

        public virtual int RatingCalculation()
        {
            return Rating;
        }
        
    }
}

