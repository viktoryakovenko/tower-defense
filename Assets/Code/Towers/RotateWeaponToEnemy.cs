using UnityEngine;

namespace Code.Towers
{
    public class RotateWeaponToEnemy : MonoBehaviour
    {
        public Transform Weapon;

        [SerializeField] private float _speed;
        [SerializeField] private Transform _enemyTransform;

        private Vector3 _positionToLook;

        private void Update()
        {
            if (Initialized())
                RotateTowardsEnemy();
        }

        private void RotateTowardsEnemy()
        {
            UpdatePositionToLookAt();

            Weapon.rotation = RotateTowards(Weapon.rotation, _positionToLook);
        }

        private void UpdatePositionToLookAt() =>
            _positionToLook = _enemyTransform.position - Weapon.position;

        private Quaternion RotateTowards(Quaternion currentRotation, Vector3 positionToLook) =>
            Quaternion.RotateTowards(currentRotation, TargetRotation(positionToLook), SpeedFactor());

        private Quaternion TargetRotation(Vector3 positionToLook) =>
            Quaternion.FromToRotation(Vector3.up, positionToLook);

        private float SpeedFactor() =>
            _speed * Time.deltaTime;

        private bool Initialized() =>
            _enemyTransform != null;
    }
}
