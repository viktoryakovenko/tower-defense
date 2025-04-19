using Code.Infrastructure.Services;
using Code.Infrastructure.Services.GameObjectPool;
using Code.Projectiles;
using UnityEngine;

namespace Code.Towers
{
    public class WeaponAttack : MonoBehaviour
    {
        [SerializeField] private WeaponAnimator _weaponAnimator;
        [SerializeField] private int _projectilesCount;

        [SerializeField] private Transform _muzzlePoint;
        [SerializeField] private Projectile _projectile;
        [SerializeField] private float _attackCooldown;

        [SerializeField] private Transform _enemy;

        private bool _isAttacking;
        private bool _attackIsActive;
        private float _currentAttackCooldown;
        private GameObjectPool<Projectile> _projectilePool;
        private float _damage;

        private void Awake()
        {
            Construct(_projectile, _attackCooldown, 10f);
        }

        public void Construct(Projectile projectile, float attackCooldown, float damage)
        {
            _projectile = projectile;
            _attackCooldown = attackCooldown;
            _damage = damage;
            _projectilePool = new GameObjectPool<Projectile>(_projectile, _projectilesCount, new GameObject("[Projectiles]").transform);
        }

        private void Update()
        {
            if (CanAttack())
                StartAttack();

            UpdateCooldown();
        }

        public void EnableAttack() =>
            _attackIsActive = true;

        public void DisableAttack() =>
            _attackIsActive = false;

        private void OnAttackEnded()
        {
            _currentAttackCooldown = _attackCooldown;
            _isAttacking = false;
        }

        private void OnShot()
        {
            _projectilePool.GetFreeElement(projectile =>
            {
                projectile.Construct(_damage, _enemy);
                projectile.transform.position = _muzzlePoint.position;
                projectile.transform.up = _muzzlePoint.up;
            });
        }

        private void StartAttack()
        {
            _weaponAnimator.PlayAttack();

            _isAttacking = true;
        }

        private void UpdateCooldown()
        {
            if (!CooldownIsUp())
                _currentAttackCooldown -= Time.deltaTime;
        }

        private bool CanAttack() =>
            _attackIsActive && !_isAttacking && CooldownIsUp();

        private bool CooldownIsUp() =>
            _currentAttackCooldown <= 0;
    }
}
