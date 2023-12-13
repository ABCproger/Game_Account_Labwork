using Game_Account_Labwork.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Account_Labwork.Entities.Managers
{
    public class ConsoleManager : IConsoleManager
    {
        private readonly IProgramManager _programManager;
        private readonly Dictionary<string, Action> _commands;

        public ConsoleManager(IProgramManager programManager)
        {
            _programManager = programManager;

            _commands = new Dictionary<string, Action>
            {
                {"1", () => AddPlayer()},
                {"2", () => _programManager.DisplayPlayers()},
                {"3", () => _programManager.DisplayGames()},
                {"4", () => _programManager.DisplayPlayerStats()},
                {"5", () => _programManager.PlayGame()},
                {"0", () => Environment.Exit(0)}
            };
        }

        public void Run()
        {
            while (true)
            {
                DisplayMenu();
                string userInput = Console.ReadLine();

                if (_commands.TryGetValue(userInput, out Action command))
                {
                    command.Invoke();
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid command number.");
                }
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine("Please choose a command:");
            Console.WriteLine("1: Add Player");
            Console.WriteLine("2: Display Players");
            Console.WriteLine("3: Display Games");
            Console.WriteLine("4: Display Player Stats");
            Console.WriteLine("5: Play Game");
            Console.WriteLine("0: Exit");
        }


        private void AddPlayer()
        {
            while (true)
            {
                Console.Write("Enter player name: ");
                string playerName = Console.ReadLine();

                Console.Write("Enter current rating: ");
                if (int.TryParse(Console.ReadLine(), out int currentRating))
                {
                    Console.Write("Choose account type (premium, standard, training): ");
                    string accountType = Console.ReadLine();

                    if (IsValidAccountType(accountType))
                    {
                        _programManager.AddPlayer(playerName, currentRating, accountType);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid account type. Please enter a valid account type.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid rating. Please enter a valid integer rating.");
                }
            }
        }

        private bool IsValidAccountType(string accountType)
        {
            return accountType == "premium" || accountType == "standard" || accountType == "training";
        }


    }

}
