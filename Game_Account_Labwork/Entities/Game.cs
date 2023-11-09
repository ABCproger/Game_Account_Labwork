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
        public string OpponentName { get; set; }
        public bool IsWin { get; set; }
        public int Rating { get; set; }
        public int GameAccountId { get; set; }
        public GameAccount GameAccount { get; set; }
    }
}

