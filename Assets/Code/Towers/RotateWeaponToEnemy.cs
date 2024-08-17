using UnityEngine;

namespace Code.Towers
{
    public class RotateWeaponToEnemy : MonoBehaviour
    {
        public Transform Weapon;

        public Transform EnemyTransform => _enemyTransform;

        [SerializeField] private float _speed;
        [SerializeField] private Transform _enemyTransform;

        private Vector2 _positionToLook;

        private void Update()
        {
            if (Initialized())
                RotateTowardsEnemy();
        }

        private void RotateTowardsEnemy()
        {
            UpdatePositionToLookAt();

            Weapon.rotation = TargetRotation(_positionToLook);;
        }

        private void UpdatePositionToLookAt() =>
            _positionToLook = _enemyTransform.position - Weapon.position;

        private Quaternion TargetRotation(Vector2 positionToLook) =>
            Quaternion.AngleAxis(TargetAngle(positionToLook), Vector3.forward);

        private float TargetAngle(Vector2 positionToLook)
        {
            float angle = Mathf.Atan2(positionToLook.y, positionToLook.x) * Mathf.Rad2Deg - 90;
            if (angle < 0)
                angle += 360f;

            return angle;
        }

        private float SpeedFactor() =>
            _speed * Time.deltaTime;

        private bool Initialized() =>
            _enemyTransform != null;
    }
}
