using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Game_Account_Labwork.appContext;
using Game_Account_Labwork.Entities;
using Game_Account_Labwork.Entities.GameAccounts;
using Game_Account_Labwork.Entities.Games;
using Game_Account_Labwork.Entities.Managers;
using Game_Account_Labwork.Factories;
using Game_Account_Labwork.Intefaces;
using Game_Account_Labwork.Services;
using Microsoft.EntityFrameworkCore;

namespace EF_Labwork
{


    class Program
    {
        static void Main()
        {
            using (var _context = new ApplicationContext())
            {
                IProgramManager programManager = new ProgramManager(_context);
                IConsoleManager consoleManager = new ConsoleManager(programManager);
                consoleManager.Run();
            }
        }
    }
}
