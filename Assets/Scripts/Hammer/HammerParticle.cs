using UnityEngine;

namespace Hammer
{
    [RequireComponent(typeof(ParticleSystem))]
    
    public class HammerParticle : MonoBehaviour
    {
        private ParticleSystem _particle;
        private HammerHandler _handler;

        private void Awake()
        {
            _particle = GetComponent<ParticleSystem>();
            _handler = GetComponentInParent<HammerHandler>();
        }

        private void OnEnable()
        {
            _handler.TookDamage += PlayParticle;
        }

        private void OnDisable()
        {
            _handler.TookDamage -= PlayParticle;
        }

        private void PlayParticle(int heartsCount)
        {
            _particle.Play();
        }
    }
}