using UnityEngine;

namespace Code.Towers
{
    public class WeaponAnimator : MonoBehaviour
    {
        private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");
        private static readonly int AttackSpeed = Animator.StringToHash("AttackSpeed");

        private readonly int _attackStateHash = Animator.StringToHash("Attack");
        private readonly int _idleStateHash = Animator.StringToHash("Idle");

        private Animator _animator;

        public WeaponAnimatorState State { get; private set; }

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Attack(float attackSpeed)
        {
            _animator.SetBool(IsAttacking, true);
            _animator.SetFloat(AttackSpeed, attackSpeed);
        }

        public void StopAttack() =>
            _animator.SetBool(IsAttacking, false);
    }
}
