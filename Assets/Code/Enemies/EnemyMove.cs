using UnityEngine;

namespace Code.Enemies
{
    public class EnemyMove : MonoBehaviour
    {
        public float MoveSpeed;

        public void Move(Vector3 to)
        {
            float normalizedSpeed = MoveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, to, normalizedSpeed);
        }
    }
}