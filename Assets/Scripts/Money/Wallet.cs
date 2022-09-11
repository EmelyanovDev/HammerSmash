using UnityEngine;

namespace Money
{
    public class Wallet : MonoBehaviour
    {
        private const string _moneyKey = "MoneyCount";
        private int _moneyCount;

        public int MoneyCount => _moneyCount;

        public void ChangeMoney(int count)
        {
            _moneyCount += count;
            PlayerPrefs.SetInt(_moneyKey, _moneyCount);
        }
    }
}