using UnityEngine;

namespace Code.Enemies
{
    public class EnemyAnimator : MonoBehaviour
    {
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Hit = Animator.StringToHash("Hit");
        private static readonly int Die = Animator.StringToHash("Die");

        private Animator _animator;

        private void Awake() =>
            _animator = GetComponent<Animator>();

        public void PlayAttack() =>
            _animator.SetTrigger(Attack);

        public void PlayHit() =>
            _animator.SetTrigger(Hit);

        public void PlayDeath() =>
            _animator.SetTrigger(Die);
    }
}
