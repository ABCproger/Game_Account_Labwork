using Game_Account_Labwork.Entities.GameAccounts;
using Game_Account_Labwork.Entities.Games;
using Game_Account_Labwork.Intefaces;
using Game_Account_Labwork.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Account_Labwork.Factories
{
    public class GameAccountFactory
    {
        public GameAccount CreateTrainingAccount(string userName, int currentRating)
        {
            return new TrainingGameAccount(userName, currentRating);
        }

        public GameAccount CreatePremiumAccount(string userName, int currentRating)
        {
            return new PremiumGameAccount(userName, currentRating);
        }

        public GameAccount CreateStandardAccount(string userName, int currentRating)
        {
            return new GameAccount(userName, currentRating);
        }

    }
}
