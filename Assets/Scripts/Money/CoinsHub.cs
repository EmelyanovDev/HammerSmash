using UnityEngine;

namespace Money
{
    public class CoinsHub : MonoBehaviour
    {
        private Coin[] _coins;

        private void Awake()
        {
            _coins = FindObjectsOfType<Coin>();
        }

        private void OnEnable()
        {
            foreach (var coin in _coins)
                coin.CoinPicked += Wallet.AddMoney;
        }
        
        private void OnDisable()
        {
            foreach (var coin in _coins)
                coin.CoinPicked -= Wallet.AddMoney;
        }
    }
}