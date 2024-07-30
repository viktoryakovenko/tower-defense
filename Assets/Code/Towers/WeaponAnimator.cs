using UnityEngine;

namespace Code.Towers
{
    public class WeaponAnimator : MonoBehaviour
    {
        private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");

        [SerializeField] private Animator _weaponAnimator;

        public void PlayAttack() =>
            _weaponAnimator.SetTrigger(IsAttacking);
    }
}
