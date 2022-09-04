using System;
using UnityEngine;

namespace Hammer
{
    [RequireComponent(typeof(ParticleSystem))]
    
    public class HammerParticle : MonoBehaviour
    {
        private ParticleSystem _particle;

        private void Awake()
        {
            _particle = GetComponent<ParticleSystem>();
        }

        private void OnEnable()
        {
            HammerCollision.HammerWasAttacked += PlayParticle;
        }

        private void OnDisable()
        {
            HammerCollision.HammerWasAttacked -= PlayParticle;
        }

        private void PlayParticle()
        {
            _particle.Play();
        }
    }
}