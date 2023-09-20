using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
