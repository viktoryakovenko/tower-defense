using UnityEngine;

namespace Code.Towers
{
    [RequireComponent(typeof(WeaponAttack))]
    public class CheckAttackRange : MonoBehaviour
    {
        public WeaponAttack WeaponAttack;
        public TriggerObserver TriggerObserver;

        private void Start()
        {
            TriggerObserver.TriggerEnter += TriggerEnter;
            TriggerObserver.TriggerExit -= TriggerExit;

            WeaponAttack.DisableAttack();
        }

        private void TriggerExit(Collider2D collider) =>
            WeaponAttack.DisableAttack();

        private void TriggerEnter(Collider2D collider) =>
            WeaponAttack.EnableAttack();
    }
}
