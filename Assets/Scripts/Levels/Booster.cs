using System;
using UnityEngine;

namespace Levels
{
    public class Booster : MonoBehaviour
    {
        [SerializeField] private float _pushForce;
        
        private void OnTriggerStay(Collider other)
        {
            if(other.gameObject.TryGetComponent(out Rigidbody rigidbody))
                rigidbody.AddForce(_pushForce * transform.right);
        }
    }
}
