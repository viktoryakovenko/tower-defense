using Code.Infrastructure.Services;
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

        private void Awake()
        {
            _projectile.Construct(10, _enemy);
            Construct(_projectile, _attackCooldown);
        }

        public void Construct(Projectile projectile, float attackCooldown)
        {
            _projectile = projectile;
            Debug.Log(projectile.Damage);
            _attackCooldown = attackCooldown;
            _projectilePool = new GameObjectPool<Projectile>(_projectile, _projectilesCount, _muzzlePoint);
        }

        public void Construct(float attackCooldown)
        {
            _attackCooldown = attackCooldown;
            _projectilePool = new GameObjectPool<Projectile>(_projectile, _projectilesCount, _muzzlePoint);
        }

        private void Update()
        {
            UpdateCooldown();

            if (CanAttack())
                StartAttack();
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
            _projectilePool.GetFreeElement();
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
