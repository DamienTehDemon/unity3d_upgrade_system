﻿using Damien.UpgradeSystem.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Damien.UpgradeSystem.Interfaces
{
    public interface IStatisticController
    {
        void Initialize();
        Statistic GetStatistic(string statisticName);
        int GetCurrentStatisticValue(string statisticName);
        Dictionary<Statistic, int> GetCurrentStatisticValues();
        Task Buff(Statistic statistic, int amount, int timeInMs);
        Task Debuff(Statistic statistic, int amount, int timeInMs);
    }
}