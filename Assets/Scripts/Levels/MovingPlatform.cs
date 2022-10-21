using System.Collections;
using UnityEngine;

namespace Levels
{
    [RequireComponent(typeof(Rigidbody))]
    
    public class MovingPlatform : MonoBehaviour
    {
        [SerializeField] private Transform[] _movingPoints;
        [SerializeField] private float _movingSpeed;
        [SerializeField] private float _stayDelay;

        private int _currentPointIndex;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            StartCoroutine(MoveToNextPoint());
        }

        private IEnumerator MoveToNextPoint()
        {
            while (transform.position != _movingPoints[_currentPointIndex].position)
            {
                float speed = _movingSpeed * Time.fixedDeltaTime;
                Vector3 point = _movingPoints[_currentPointIndex].position;
                Vector3 target = Vector3.MoveTowards(transform.position, point, speed);
                _rigidbody.MovePosition(target);
                yield return new WaitForFixedUpdate();
            }
            _currentPointIndex = ++_currentPointIndex % _movingPoints.Length;
            
            yield return new WaitForSeconds(_stayDelay);
            StartCoroutine(MoveToNextPoint());
        }
    }
}