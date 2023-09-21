using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Game_Account_Labwork;
using Game_Account_Labwork.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_Labwork
{


    internal class Program
    {
        static void Main(string[] args)
        {
            var difGame = new Game("thoisoi", "ChemistryEasy");
            var difGame2 = new Game("TEST", "TEST2");
            difGame.startGame();
            difGame2.startGame();

            Game.printResultOfGames();

        }

    }
}
