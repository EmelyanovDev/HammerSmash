using System.Collections;
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

        public bool HaveWayPoints => _wayPoints.Length > 0;

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
            if (_agent.enabled == false) return;
            var point = _wayPoints[_nextPointIndex];
            _agent.SetDestination(point.position);
            _nextPointIndex = ++_nextPointIndex % _wayPoints.Length;
        }

        private IEnumerator DisableAgent(float time)
        {
            _agent.enabled = false;
            yield return new WaitForSeconds(time);
            _agent.enabled = true;
        }

        public void DisableAgentForSeconds(float time)
        {
            if(HaveWayPoints) 
                StartCoroutine(DisableAgent(time));
        }

        public void TurnAgent(bool condition) => _agent.enabled = condition;
    }
}
