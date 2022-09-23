using System;
using System.Collections;
using UnityEngine;

namespace Levels
{
    public class MovingPlatform : MonoBehaviour
    {
        [SerializeField] private Transform[] _movingPoints;
        [SerializeField] private float _movingSpeed;
        [SerializeField] private float _stayDelay;

        private int _currentPointIndex;

        private void Start()
        {
            StartCoroutine(MoveToNextPoint());
        }

        private IEnumerator MoveToNextPoint()
        {
            while (transform.position != _movingPoints[_currentPointIndex].position)
            {
                float speed = _movingSpeed * Time.fixedDeltaTime;
                Vector3 pointPosition = _movingPoints[_currentPointIndex].position;
                transform.position = Vector3.MoveTowards(transform.position, pointPosition, speed);
                yield return new WaitForFixedUpdate();
            }
            _currentPointIndex = ++_currentPointIndex % _movingPoints.Length;
            
            yield return new WaitForSeconds(_stayDelay);
            StartCoroutine(MoveToNextPoint());
        }
    }
}
