using System.Collections.Generic;
using System.Linq;
using Code.StaticData;
using Code.Towers;
using UnityEngine;

namespace Code.Infrastructure.Services
{
    public class StaticDataService : IStaticDataService
    {
        private const string StaticDataTowersPath = "StaticData/Towers";

        private Dictionary<TowerTypeId, TowerStaticData> _towers;

        public void Load()
        {
            _towers = Resources
                .LoadAll<TowerStaticData>(StaticDataTowersPath)
                .ToDictionary(x => x.TowerTypeId, x => x);
        }


        public TowerStaticData ForTower(TowerTypeId typeId) =>
            _towers.TryGetValue(typeId, out TowerStaticData staticData)
                ? staticData
                : null;
    }
}
