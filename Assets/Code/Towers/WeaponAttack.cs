using Code.Projectiles;
using UnityEngine;

namespace Code.Towers
{
    public class WeaponAttack : MonoBehaviour
    {
        [SerializeField] private WeaponAnimator _weaponAnimator;
        [SerializeField] private Projectile _projectile;
        [SerializeField] private float _attackCooldown;

        private bool _isAttacking;
        private bool _attackIsActive;
        private float _currentAttackCooldown;

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
