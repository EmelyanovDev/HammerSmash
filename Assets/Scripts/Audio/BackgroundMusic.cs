using UnityEngine;

namespace Audio
{
    [RequireComponent(typeof(AudioSource))]

    public class BackgroundMusic : MonoBehaviour
    {
        [SerializeField] private AudioClip[] _songs;

        private AudioSource _audioSource;

        public static BackgroundMusic _instance {private set; get;}

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

        private void Update() 
        {
            if (_audioSource.isPlaying == false)    
                PlayRandomSong();
        }

        private void PlayRandomSong()
        {
            int index = Random.Range(0, _songs.Length);
            _audioSource.PlayOneShot(_songs[index]);
        }
    }
}