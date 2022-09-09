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
            _handler.HammerWasAttacked += PlayParticle;
        }

        private void OnDisable()
        {
            _handler.HammerWasAttacked -= PlayParticle;
        }

        private void PlayParticle()
        {
            _particle.Play();
        }
    }
}