using UnityEngine;

namespace Code.Enemies
{
    public class EnemyMove : MonoBehaviour
    {
        public float MoveSpeed;

        private void Update()
        {
            float normalizedSpeed = MoveSpeed * Time.deltaTime;
            transform.position += new Vector3(normalizedSpeed, 0);
        }
    }
}