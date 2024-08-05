using Code.Projectiles;
using Code.StaticData;
using Code.Towers;
using UnityEngine;

namespace Code.Infrastructure.Services
{
    public class GameFactory : IGameFactory
    {
        private StaticDataService _staticData;

        public GameObject CreateTower(TowerTypeId typeId, Transform parent)
        {
            TowerStaticData towerStaticData = _staticData.ForTower(typeId);

            GameObject tower = Object.Instantiate(towerStaticData.Prefab, parent.position, Quaternion.identity, parent);

            Projectile projectile = towerStaticData.Projectile;
            projectile.Construct(towerStaticData.Damage);

            tower.GetComponent<WeaponAttack>().Construct(projectile, towerStaticData.AttackCooldown);

            return tower;
        }
    }
}
