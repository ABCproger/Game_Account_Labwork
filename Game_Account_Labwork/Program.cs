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
            GameAccount player1 = new GameAccount("thoisoi");
            GameAccount player2 = new GameAccount("ChemistryEasy");

            var difGame = new Game(player1.UserName, player2.UserName);

            difGame.startGame(player1,player2);
            player1.GetStats();
        }

    }
}
