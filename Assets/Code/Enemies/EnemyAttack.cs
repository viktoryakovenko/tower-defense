using UnityEngine;

namespace Code.Enemies
{
    [RequireComponent(typeof(EnemyAnimator))]
    public class EnemyAttack : MonoBehaviour
    {
        public EnemyAnimator Animator;
        public float Damage;
        public float AttackCooldown;

        private bool _isAttacking;
        private bool _attackIsActive;
        private float _attackCooldown;

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
            _attackCooldown = AttackCooldown;
            _isAttacking = false;
        }

        private void StartAttack()
        {
            Animator.PlayAttack();

            _isAttacking = true;
        }

        private void UpdateCooldown()
        {
            if (!CooldownIsUp())
                _attackCooldown -= Time.deltaTime;
        }

        private bool CanAttack() =>
            _attackIsActive && !_isAttacking && CooldownIsUp();

        private bool CooldownIsUp() =>
            _attackCooldown <= 0;
    }
}
