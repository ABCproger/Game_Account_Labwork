﻿using Game_Account_Labwork.Entities.GameAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Account_Labwork.Intefaces
{
    public interface IGameAccountService
    {
        GameAccount CreateStandardAccount(string userName, int currentRating);
        GameAccount CreatePremiumAccount(string userName,int currentRating);
        GameAccount CreateTrainingAccount(string userName, int currentRating);
        List<GameAccount> GetAllGameAccounts();
    }
}
