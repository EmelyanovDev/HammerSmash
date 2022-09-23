using System;
using System.Collections;
using Hammer;
using UnityEngine;

namespace Levels
{
    public class Hook : MonoBehaviour
    {
        [SerializeField] private Transform _finishPoint;
        [SerializeField] private float _moveSpeed;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out HammerHead head))
                StartCoroutine(MoveHammer(head));
        }

        private IEnumerator MoveHammer(HammerHead head)
        {
            head.Hook(true);
            while (head.transform.position != _finishPoint.position)
            {
                float speed = _moveSpeed * Time.fixedDeltaTime;
                head.transform.position = Vector3.MoveTowards(head.transform.position, _finishPoint.position, speed);
                yield return new WaitForFixedUpdate();
            }
            head.Hook(false);
        }
    }
}
