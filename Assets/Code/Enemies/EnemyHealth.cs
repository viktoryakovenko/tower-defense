using System;
using System.Collections;
using Code.Logic;
using UnityEngine;

namespace Code.Enemies
{
    [RequireComponent(typeof(EnemyAnimator))]
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        public event Action HealthChanged;

        public EnemyAnimator Animator;

        [SerializeField] private float _current;
        [SerializeField] private float _max;

        public float Current
        {
            get => _current;
            set => _current = value;
        }

        public float Max
        {
            get => _max;
            set => _max = value;
        }

        private void Start()
        {
            StartCoroutine(TakeDamageEveryFiveSeconds());
        }

        public void TakeDamage(float damage)
        {
            Current -= damage;

            Animator.PlayHit();

            HealthChanged?.Invoke();
        }

        private IEnumerator TakeDamageEveryFiveSeconds()
        {
            while (true)
            {
                yield return new WaitForSeconds(5f);
                TakeDamage(5);
            }
        }
    }
}
