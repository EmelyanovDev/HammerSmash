using UnityEngine;

namespace Audio
{
    [RequireComponent(typeof(AudioSource))]

    public class SoundEffects : MonoBehaviour
    {
        public static SoundEffects _instance {private set; get;}

        private AudioSource _audioSource;

        private void Awake() 
        {
            Singleton();

            _audioSource = GetComponent<AudioSource>();
        }

        private void Singleton()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    
        private void PlayOneShot(AudioClip clip) => _audioSource.PlayOneShot(clip);

        [SerializeField] private AudioClip _enemyAttackSound, _enemyDieSound, _enemyTakeDamageSound;
        public void PlayEnemyAttackSound() => PlayOneShot(_enemyAttackSound);
        public void PlayEnemyDieSound() => PlayOneShot(_enemyDieSound);
        public void PlayEnemyTakeDamageSound() => PlayOneShot(_enemyTakeDamageSound);
        
        [SerializeField] private AudioClip _coinTakeSound;
        public void PlayCoinTakeSound() => PlayOneShot(_coinTakeSound);

        [SerializeField] private AudioClip _purchaseSucceededSound, _purchaseFailSound;
        public void PlayPurshaseSucceededSound() => PlayOneShot(_purchaseSucceededSound);
        public void PlayPurshaseFailSound() => PlayOneShot(_purchaseFailSound);
    }
}