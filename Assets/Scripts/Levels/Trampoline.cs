using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private float _repulsiveForce;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Rigidbody rigidbody))
            rigidbody.AddForce(transform.up * _repulsiveForce);
    }
}
