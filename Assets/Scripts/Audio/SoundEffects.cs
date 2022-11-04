using UnityEngine;

namespace Audio
{
    [RequireComponent(typeof(AudioSource))]

    public class SoundEffects : MonoBehaviour
    {
        [SerializeField] private AudioClip _purchaseSucceededSound, _purchaseFailSound;
        [SerializeField] private AudioClip _enemyAttackSound, _enemyDieSound, _enemyTakeDamageSound;
        [SerializeField] private AudioClip _coinTakeSound;
        
        private AudioSource _audioSource;
        
        public static SoundEffects Instance {private set; get;}

        private void Awake() 
        {
            Singleton();
            _audioSource = GetComponent<AudioSource>();
        }

        private void Singleton()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    
        private void PlayOneShot(AudioClip clip) => _audioSource.PlayOneShot(clip);
        
        public void PlayEnemyAttackSound() => PlayOneShot(_enemyAttackSound);
        public void PlayEnemyDieSound() => PlayOneShot(_enemyDieSound);
        public void PlayEnemyTakeDamageSound() => PlayOneShot(_enemyTakeDamageSound);
        
        public void PlayCoinTakeSound() => PlayOneShot(_coinTakeSound);
        
        public void PlayPurshaseSucceededSound() => PlayOneShot(_purchaseSucceededSound);
        public void PlayPurshaseFailSound() => PlayOneShot(_purchaseFailSound);
    }
}