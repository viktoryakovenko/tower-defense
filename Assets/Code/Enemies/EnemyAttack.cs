using UnityEngine;

namespace Code.Enemies
{
    [RequireComponent(typeof(EnemyAnimator))]
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private EnemyAnimator _animator;
        [SerializeField] private float _damage;
        [SerializeField] private float _attackCooldown;

        private bool _isAttacking;
        private bool _attackIsActive;
        private float _currentAttackCooldown;

        private void Awake() =>
            _attackIsActive = true;

        private void Update()
        {
            UpdateCooldown();

            if (CanAttack())
                StartAttack();
        }

        private void OnAttackEnded()
        {
            _currentAttackCooldown = _attackCooldown;
            _isAttacking = false;
        }

        private void StartAttack()
        {
            _animator.PlayAttack();

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
