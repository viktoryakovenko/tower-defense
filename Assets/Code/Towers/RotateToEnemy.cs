using UnityEngine;

namespace Code.Towers
{
    public class RotateToEnemy : MonoBehaviour
    {
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

            transform.rotation = SmoothedRotation(transform.rotation, _positionToLook);
        }

        private void UpdatePositionToLookAt() =>
            _positionToLook = _enemyTransform.position - transform.position;

        private Quaternion SmoothedRotation(Quaternion rotation, Vector3 positionToLook) =>
            Quaternion.Lerp(rotation, TargetRotation(positionToLook), SpeedFactor());

        private Quaternion TargetRotation(Vector3 positionToLook)
        {
            float angle = Mathf.Atan2(positionToLook.y, positionToLook.x) * Mathf.Rad2Deg - 90f;
            return Quaternion.AngleAxis(angle, Vector3.forward);
        }

        private float SpeedFactor() =>
            _speed * Time.deltaTime;

        private bool Initialized() =>
            _enemyTransform != null;
    }
}
