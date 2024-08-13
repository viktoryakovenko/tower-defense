using Code.StaticData;
using Code.Towers;
using UnityEngine;

namespace Code.Infrastructure.Services
{
    public class GameFactory : IGameFactory
    {
        private IStaticDataService _staticData;

        public GameFactory(IStaticDataService staticData)
        {
            _staticData = staticData;
        }

        public GameObject CreateTower(TowerTypeId typeId, Transform parent)
        {
            TowerStaticData towerStaticData = _staticData.ForTower(typeId);

            GameObject tower = Object.Instantiate(towerStaticData.Prefab, parent.position, Quaternion.identity, parent);

            tower.GetComponent<WeaponAttack>().Construct(towerStaticData.Projectile, towerStaticData.AttackCooldown, towerStaticData.Damage);

            return tower;
        }
    }
}
