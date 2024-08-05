using Code.Projectiles;
using Code.Towers;
using UnityEngine;

namespace Code.StaticData
{
    [CreateAssetMenu(fileName = "TowerData", menuName = "StaticData/Tower")]
    public class TowerStaticData : ScriptableObject
    {
        public TowerTypeId TowerTypeId;

        public Projectile Projectile;

        public float Damage;

        public float AttackCooldown;

        public GameObject Prefab;
    }
}
