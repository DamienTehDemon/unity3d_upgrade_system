using Damien.UpgradeSystem.Exceptions;
using Damien.UpgradeSystem.Interfaces;
using Damien.UpgradeSystem.ScriptableObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Damien.UpgradeSystem
{
    public class UpgradeSystem : MonoBehaviour
    {
        #region Private Variables
        private UpgradeController _upgradeController;
        private StatisticController _statisticController;
        #endregion

        #region Configuration
        #endregion

        public void Save()
        {
            string saveContent = JsonUtility.ToJson(_upgradeController.GetCurrentUpgrades());
            System.IO.File.WriteAllText(Application.persistentDataPath + "/UpgradeSystemSave.data", saveContent);
        }

        public List<Upgrade> GetAllUpgrades()
        {
            return _upgradeController.GetAllUpgrades().ToModel();
        }

        public List<Upgrade> GetCurrentUpgrades()
        {
            return _upgradeController.GetCurrentUpgrades().ToModel();
        }

        public void GiveUpgrade(string upgradeName)
        {
            _upgradeController.GiveUpgrade(upgradeName);
        }

        public void RemoveUpgrade(string upgradeName)
        {
            _upgradeController.RemoveUpgrade(upgradeName);
        }

        public Dictionary<Statistic,int> GetStatistics()
        {
            return _statisticController.GetCurrentStatisticValues().ToModel() ;
        }

        public int GetStatisticValue(string statisticName)
        {
           return _statisticController.GetCurrentStatisticValue(statisticName);
        }

        public async void Buff(string statisticName, int amount, int timeInMs)
        {
            var statistic = _statisticController.GetStatistic(statisticName);
            await _statisticController.Buff(statisticName, amount, timeInMs);
        }

        public async void Debuff(string statisticName, int amount, int timeInMs)
        {
            var statistic = _statisticController.GetStatistic(statisticName);
            await _statisticController.Debuff(statisticName, amount, timeInMs);
        }

        private void Start()
        {
            _upgradeController = new UpgradeController();
            _statisticController = new StatisticController(_upgradeController);
            _upgradeController.Initialize();
            _statisticController.Initialize();
        }
    }
}
