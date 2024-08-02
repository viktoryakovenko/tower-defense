using System;
using System.Collections;
using UnityEngine;

namespace Code.Enemies
{
    [RequireComponent(typeof(EnemyAnimator), typeof(EnemyHealth))]
    public class EnemyDeath : MonoBehaviour
    {
        public event Action Happened;

        public EnemyHealth Health;
        public EnemyAnimator Animator;

        private void Start() =>
            Health.HealthChanged += HealthChanged;

        private void OnDestroy() =>
            Health.HealthChanged -= HealthChanged;

        private void HealthChanged()
        {
            if (Health.Current <= 0)
                Die();
        }

        private void Die()
        {
            Health.HealthChanged -= HealthChanged;
            Animator.PlayDeath();

            StopMoving();
            StartCoroutine(DestroyTimer());

            Happened?.Invoke();
        }

        private void StopMoving()
        {
            if (gameObject.TryGetComponent(out EnemyMove move))
                move.enabled = false;
        }

        private IEnumerator DestroyTimer()
        {
            yield return new WaitForSeconds(3);
            Destroy(gameObject);
        }
    }
}
