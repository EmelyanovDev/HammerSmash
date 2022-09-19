using System;
using UnityEngine;

namespace Money
{
    public static class Wallet 
    {
        private const string _moneyKey = "MoneyCount";
        private static int _moneyCount;

        public static Action<int> MoneyChanged;
        
        public static int GetMoneyCount()
        {
            if (PlayerPrefs.HasKey(_moneyKey))
                return PlayerPrefs.GetInt(_moneyKey);
            return 0;
        }

        public static void AddMoney() => ChangeMoneyCount(1);
        
        public static void ChangeMoneyCount(int count)
        {
            _moneyCount = GetMoneyCount();
            _moneyCount += count;
            PlayerPrefs.SetInt(_moneyKey, _moneyCount);
            MoneyChanged?.Invoke(_moneyCount);
        }
    }
}