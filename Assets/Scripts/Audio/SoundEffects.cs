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

        [SerializeField] private AudioClip _enemyAttackSound, _enemyDieSound;
        public void PlayEnemyAttackSound() => PlayOneShot(_enemyAttackSound);
        public void PlayEnemyDieSound() => PlayOneShot(_enemyDieSound);
    }
}