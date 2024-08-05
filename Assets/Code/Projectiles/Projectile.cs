using UnityEngine;

namespace Code.Projectiles
{
    public abstract class Projectile : MonoBehaviour
    {
        public float Damage => _damage;

        private float _damage;

        public void Construct(float damage) =>
            _damage = damage;
    }
}
