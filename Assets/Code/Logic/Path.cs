using System.Collections.Generic;
using UnityEngine;

namespace Code.Logic
{
    public class Path : MonoBehaviour
    {
        [SerializeField] private List<Transform> _waypoints;

        public List<Vector2> Waypoints
        {
            get
            {
                List<Vector2> vectorList = new List<Vector2>();

                foreach (Transform waypoint in _waypoints)
                    vectorList.Add(waypoint.position);

                return vectorList;
            }
        }
    }
}
