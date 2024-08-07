using System.Collections.Generic;
using Code.Logic;
using ModestTree;
using UnityEngine;

namespace Code.Enemies
{
    [RequireComponent(typeof(EnemyMove))]
    public class WayPointMovement : MonoBehaviour
    {
        [SerializeField] private Path _path;

        private Queue<Vector2> _waypointsQueue;
        private EnemyMove _enemyMove;
        private Vector2 _currentWayPoint;

        private void Awake()
        {
            _waypointsQueue = new Queue<Vector2>(_path.Waypoints);
            _enemyMove = GetComponent<EnemyMove>();
            _currentWayPoint = _waypointsQueue.Dequeue();
        }

        private void Update()
        {
            _enemyMove.Move(_currentWayPoint);

            if (_waypointsQueue.IsEmpty()) return;

            if (Vector2.Distance(transform.position, _currentWayPoint) < 0.05f)
                _currentWayPoint = _waypointsQueue.Dequeue();
        }
    }
}
