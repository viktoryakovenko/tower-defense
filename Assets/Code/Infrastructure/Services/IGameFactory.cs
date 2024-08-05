using Code.Towers;
using UnityEngine;

namespace Code.Infrastructure.Services
{
    public interface IGameFactory
    {
        GameObject CreateTower(TowerTypeId typeId, Transform parent);
    }
}
