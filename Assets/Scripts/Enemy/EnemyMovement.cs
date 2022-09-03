using System;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private Transform[] _wayPoints;
        
        private NavMeshAgent _agent;
        private int _nextPointIndex;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            SetNextPoint();
        }

        private void Update()
        {
            if(_agent.hasPath == false)
                SetNextPoint();
        }

        private void SetNextPoint()
        {
            var point = _wayPoints[_nextPointIndex];
            _agent.SetDestination(point.position);
            _nextPointIndex = ++_nextPointIndex % _wayPoints.Length;
        }
    }
}
