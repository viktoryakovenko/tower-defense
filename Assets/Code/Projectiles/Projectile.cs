using UnityEngine;

namespace Code.Projectiles
{
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField] private float _speed;

        public float Damage => _damage;

        private Transform _target;
        private float _damage;

        public void Construct(float damage, Transform target)
        {
            _damage = damage;
            _target = target;
        }

        private void Update()
        {
            if (TargetExists())
                FlyToEnemy(_target.position);
        }

        private void FlyToEnemy(Vector2 target) =>
            transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);

        private bool TargetExists() =>
            _target != null;
    }
}
