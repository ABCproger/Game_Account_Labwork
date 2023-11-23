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
        public Game CreateStandardGame()
        {
            return new StandardGame();
        }

        public Game CreateTrainingGame()
        {
            return new TrainingGame();
        }

        public Game CreateNoRatingGame()
        {
            return new NoRatingGame();
        }

    }
}
