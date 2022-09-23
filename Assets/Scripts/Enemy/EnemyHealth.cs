using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(EnemyHandler))]
    
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private int _heartsCount = 1;
        
        private EnemyHandler _handler;

        private void Awake()
        {
            _handler = GetComponent<EnemyHandler>();
        }

        private void OnEnable()
        {
            _handler.TookDamage += ReduceHealth;
        }
        
        private void OnDisable()
        {
            _handler.TookDamage -= ReduceHealth;
        }

        private void ReduceHealth()
        {
            _heartsCount--;
            if(_heartsCount == 0)
                _handler.Die();
        }
    }
}