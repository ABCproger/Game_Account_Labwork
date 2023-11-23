using Game_Account_Labwork.Entities.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Account_Labwork.Factories
{
    public class GameFactory
    {
        

        public Game CreateStandardGame(string firstPlayer, string secondPlayer)
        {
            return new StandardGame(firstPlayer, secondPlayer);
        }

        public Game CreateTrainingGame(string firstPlayer, string secondPlayer)
        {
            return new TrainingGame(firstPlayer, secondPlayer);
        }

        public Game CreateSingleRatingGame(string firstPlayer, string secondPlayer)
        {
            return new SingleRatingGame(firstPlayer, secondPlayer);
        }

    }
}
