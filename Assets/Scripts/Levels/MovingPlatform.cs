using UnityEngine;

namespace Levels
{
    public class MovingPlatform : MonoBehaviour
    {
        [SerializeField] private Transform[] _movingPoints;
        [SerializeField] private float _movingSpeed;

        private int _currentPointIndex;

        private void FixedUpdate()
        {
            float speed = _movingSpeed * Time.fixedDeltaTime;   
            transform.position = Vector3.MoveTowards(transform.position, _movingPoints[_currentPointIndex].position, speed);
            if(transform.position == _movingPoints[_currentPointIndex].position)
                _currentPointIndex = ++_currentPointIndex % _movingPoints.Length;
        }
    }
}
