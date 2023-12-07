using Game_Account_Labwork.Entities.GameAccounts;
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
        

        public List<Game> CreateStandardGame(GameAccount gameAccount1, GameAccount gameAccount2)
        {
            return new List<Game>
            {
                new StandardGame(gameAccount1.UserName, gameAccount2.UserName, gameAccount1.Id),
                new StandardGame(gameAccount1.UserName, gameAccount2.UserName, gameAccount2.Id)
            };
        }

        public List<Game> CreateTrainingGame(GameAccount gameAccount1, GameAccount gameAccount2)
        {
            return new List<Game>
            {
                new TrainingGame(gameAccount1.UserName, gameAccount2.UserName, gameAccount1.Id),
                new TrainingGame(gameAccount1.UserName, gameAccount2.UserName, gameAccount2.Id)
            };
        }

        public Game CreateSingleRatingGame(GameAccount gameAccount1, GameAccount gameAccount2)
        {
            return new SingleRatingGame(gameAccount1.UserName, gameAccount2.UserName);
        }

    }
}
